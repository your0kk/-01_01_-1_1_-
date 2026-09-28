using System.Windows;
using Modules1.Pages;

namespace Modules1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowTask1Page();
        }

        private void Task1Button_Click(object sender, RoutedEventArgs e)
        {
            ShowTask1Page();
        }

        private void Task2Button_Click(object sender, RoutedEventArgs e)
        {
            pageTitleTextBlock.Text = "задание 9.2  работа со строкой";
            contentFrame.Navigate(new Task2Page());
        }

        private void Task3Button_Click(object sender, RoutedEventArgs e)
        {
            pageTitleTextBlock.Text = "задание 9.3  чередование четных и нечетных чисел";
            contentFrame.Navigate(new Task3Page());
        }

        private void Task4Button_Click(object sender, RoutedEventArgs e)
        {
            pageTitleTextBlock.Text = "задача 9.4  работа с массивом";
            contentFrame.Navigate(new Task4Page());
        }

        private void Task5Button_Click(object sender, RoutedEventArgs e)
        {
            pageTitleTextBlock.Text = "задание 9.5  двумерный массив";
            contentFrame.Navigate(new Task5Page());
        }

        private void ShowTask1Page()
        {
            pageTitleTextBlock.Text = "задача 9.1  количество дней в году";
            contentFrame.Navigate(new Task1Page());
        }
    }
}
