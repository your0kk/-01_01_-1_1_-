using System;
using System.Windows;
using System.Windows.Controls;

namespace Modules1.Pages
{
    public partial class Task3Page : Page
    {
        public Task3Page()
        {
            InitializeComponent();
            arrayTextBox.Focus();
        }

        private void CheckAlternationButton_Click(object sender, RoutedEventArgs e)
        {
            validationTextBlock.Text = string.Empty;
            resultTextBox.Text = string.Empty;

            string[] parts = arrayTextBox.Text.Split(
                new[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                validationTextBlock.Text = "Ошибка!!!! введите элементы массива";
                return;
            }

            int[] numbers = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out numbers[i]) || numbers[i] == 0)
                {
                    validationTextBlock.Text =
                        "Ошибка!!! массив должен содержать только ненулевые целые числа";
                    return;
                }
            }

            int violatingPosition = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                bool currentIsEven = numbers[i] % 2 == 0;
                bool previousIsEven = numbers[i - 1] % 2 == 0;

                if (currentIsEven == previousIsEven)
                {
                    violatingPosition = i + 1;
                    break;
                }
            }

            if (violatingPosition == 0)
            {
                resultTextBox.Text =
                    "результат: четные и нечетные числа чередуются";
            }
            else
            {
                resultTextBox.Text = string.Format(
                    "первый элемент, нарушающий чередование, имеет номер: {0}.",
                    violatingPosition);
            }
        }
    }
}
