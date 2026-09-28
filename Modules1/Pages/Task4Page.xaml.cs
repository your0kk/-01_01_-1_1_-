using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Modules1.Pages
{
    public partial class Task4Page : Page
    {
        public Task4Page()
        {
            InitializeComponent();
            arrayTextBox.Focus();
        }

        private void SwapElementsButton_Click(object sender, RoutedEventArgs e)
        {
            validationTextBlock.Text = string.Empty;
            resultTextBox.Text = string.Empty;

            string[] parts = arrayTextBox.Text.Split(
                new[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
            {
                validationTextBlock.Text =
                    "ошибка!!! введите не менее двух целых чисел";
                return;
            }

            int[] numbers = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out numbers[i]))
                {
                    validationTextBlock.Text =
                        "ошибка!! массив должен содержать только целые числа";
                    return;
                }
            }

            int maximum = numbers.Max();
            long minimumDifference = long.MaxValue;
            int firstIndex = 0;
            int secondIndex = 1;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    long sum = (long)numbers[i] + numbers[j];
                    long difference = Math.Abs(sum - maximum);

                    if (difference < minimumDifference)
                    {
                        minimumDifference = difference;
                        firstIndex = i;
                        secondIndex = j;
                    }
                }
            }

            int firstValue = numbers[firstIndex];
            int secondValue = numbers[secondIndex];

            numbers[firstIndex] = secondValue;
            numbers[secondIndex] = firstValue;

            resultTextBox.Text = string.Format(
                "максимальный элемент: {0}.\r\n" +
                "выбраны элементы {1} и {2}, их номера: {3} и {4}.\r\n" +
                "массив после перестановки: {5}",
                maximum,
                firstValue,
                secondValue,
                firstIndex + 1,
                secondIndex + 1,
                string.Join(" ", numbers));
        }
    }
}
