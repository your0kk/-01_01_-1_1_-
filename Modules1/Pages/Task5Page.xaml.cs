using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Modules1.Pages
{
    public partial class Task5Page : Page
    {
        private readonly Random random = new Random();

        public Task5Page()
        {
            InitializeComponent();
            rowsTextBox.Focus();
        }

        private void GenerateArrayButton_Click(object sender, RoutedEventArgs e)
        {
            validationTextBlock.Text = string.Empty;
            resultTextBlock.Text = string.Empty;
            sourceDataGrid.ItemsSource = null;
            ascendingDataGrid.ItemsSource = null;
            descendingDataGrid.ItemsSource = null;

            int rows;
            int columns;

            if (!int.TryParse(rowsTextBox.Text.Trim(), out rows) ||
                !int.TryParse(columnsTextBox.Text.Trim(), out columns) ||
                rows < 1 || rows > 10 || columns < 1 || columns > 10)
            {
                validationTextBlock.Text =
                    "ошибка!! количество строк и столбцов должно быть от 1 до 10";
                return;
            }

            int[,] sourceArray = new int[rows, columns];
            int[] elements = new int[rows * columns];
            int minimum = 10;
            int maximum = -10;
            int elementIndex = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int value = random.Next(-10, 11);
                    sourceArray[i, j] = value;
                    elements[elementIndex] = value;
                    elementIndex++;

                    if (value < minimum)
                    {
                        minimum = value;
                    }

                    if (value > maximum)
                    {
                        maximum = value;
                    }
                }
            }

            Array.Sort(elements);

            int[,] ascendingArray = FillArray(elements, rows, columns, false);
            int[,] descendingArray = FillArray(elements, rows, columns, true);

            sourceDataGrid.ItemsSource = CreateTable(sourceArray).DefaultView;
            ascendingDataGrid.ItemsSource = CreateTable(ascendingArray).DefaultView;
            descendingDataGrid.ItemsSource = CreateTable(descendingArray).DefaultView;

            resultTextBlock.Text = string.Format(
                "минимальный элемент: {0}. максимальный элемент: {1}.",
                minimum,
                maximum);
        }

        private int[,] FillArray(int[] elements, int rows, int columns, bool reverse)
        {
            int[,] result = new int[rows, columns];
            int index = reverse ? elements.Length - 1 : 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = elements[index];
                    index += reverse ? -1 : 1;
                }
            }

            return result;
        }

        private DataTable CreateTable(int[,] array)
        {
            DataTable table = new DataTable();
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            for (int j = 0; j < columns; j++)
            {
                table.Columns.Add((j + 1).ToString(), typeof(int));
            }

            for (int i = 0; i < rows; i++)
            {
                DataRow row = table.NewRow();

                for (int j = 0; j < columns; j++)
                {
                    row[j] = array[i, j];
                }

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
