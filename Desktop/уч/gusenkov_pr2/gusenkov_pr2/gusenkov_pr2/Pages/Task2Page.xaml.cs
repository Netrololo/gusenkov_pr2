using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gusenkov_pr2.Pages
{
    public partial class Task2Page : Page
    {
        public Task2Page()
        {
            InitializeComponent();
            txtTaskDescription2.Text = "Задача 2. Дана строка-предложение на русском языке. Преобразовать строку так, чтобы каждое слово начиналось с заглавной буквы.";
        }

        private void btnCalculate2_Click(object sender, RoutedEventArgs e)
        {
            string inputText = tbInputData2.Text;

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Ошибка валидации! Входное предложение не может быть пустым.", "Система проверки", MessageBoxButton.OK, MessageBoxImage.Error);
                tbInputData2.Focus();
                return;
            }

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string capitalizedText = textInfo.ToTitleCase(inputText);

            tbResultData2.Text = $"Исходный текст:\n{inputText}\n\n" +
                                 $"Результат обработки (Capitalized):\n{capitalizedText}";
        }
    }
}