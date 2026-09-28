using System.Windows;
using System.Windows.Controls;

namespace Modules1.Pages
{
    public partial class Task1Page : Page
    {
        public Task1Page()
        {
            InitializeComponent();
            yearTextBox.Focus();
        }

        private void CalculateDaysButton_Click(object sender, RoutedEventArgs e)
        {
            validationTextBlock.Text = string.Empty;
            resultTextBox.Text = string.Empty;

            int year;

            if (!int.TryParse(yearTextBox.Text.Trim(), out year) || year <= 0)
            {
                validationTextBlock.Text = "Ошибка!!!! введите положительное целое число";
                yearTextBox.Focus();
                yearTextBox.SelectAll();
                return;
            }

            bool isLeapYear = year % 400 == 0 ||
                              year % 4 == 0 && year % 100 != 0;

            int daysInYear = isLeapYear ? 366 : 365;

            resultTextBox.Text = string.Format(
                "{0} год - {1} дней ({2}).",
                year,
                daysInYear,
                isLeapYear ? "високосный" : "обычный");
        }
    }
}
