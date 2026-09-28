using System;
using System.Windows;
using System.Windows.Controls;

namespace Modules1.Pages
{
    public partial class Task2Page : Page
    {
        public Task2Page()
        {
            InitializeComponent();
            sourceTextBox.Focus();
        }

        private void CountWordsButton_Click(object sender, RoutedEventArgs e)
        {
            validationTextBlock.Text = string.Empty;
            resultTextBox.Text = string.Empty;

            string sourceText = sourceTextBox.Text;

            if (string.IsNullOrWhiteSpace(sourceText))
            {
                validationTextBlock.Text = "ошибка!!! введите строку.";
                sourceTextBox.Focus();
                return;
            }

            string[] words = sourceText.Split(
                new[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            int matchingWordsCount = 0;

            foreach (string word in words)
            {
                int letterCount = 0;

                foreach (char character in word)
                {
                    if (char.ToLower(character) == 'а')
                    {
                        letterCount++;
                    }
                }

                if (letterCount == 3)
                {
                    matchingWordsCount++;
                }
            }

            resultTextBox.Text = string.Format(
                "количество слов с тремя буквами А: {0}",
                matchingWordsCount);
        }
    }
}
