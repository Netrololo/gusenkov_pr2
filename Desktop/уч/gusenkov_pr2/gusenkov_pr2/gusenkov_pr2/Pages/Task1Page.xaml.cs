using System;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace gusenkov_pr2.Pages
{
    public partial class Task1Page : Page
    {
        public Task1Page()
        {
            InitializeComponent();
            txtTaskDescription1.Text = "Задача 1. Определить количество повторений каждой из цифр 0,1,2,...,9 в числе N^N (N в степени N), N <= 1000.";
        }

        private void btnCalculate1_Click(object sender, RoutedEventArgs e)
        {
            string rawInput = tbInputData1.Text.Trim();

            if (!int.TryParse(rawInput, out int n))
            {
                MessageBox.Show("Ошибка валидации! Введите корректное целое число N.", "Система проверки", MessageBoxButton.OK, MessageBoxImage.Error);
                tbInputData1.Focus();
                return;
            }

            if (n < 1 || n > 1000)
            {
                MessageBox.Show("Ошибка валидации! Число N должно быть в диапазоне от 1 до 1000.", "Система проверки", MessageBoxButton.OK, MessageBoxImage.Error);
                tbInputData1.Focus();
                return;
            }

            BigInteger bigN = new BigInteger(n);
            BigInteger powerResult = BigInteger.Pow(bigN, n);

            string numberString = powerResult.ToString();

            int[] digitCounts = new int[10];

            foreach (char symbol in numberString)
            {
                if (char.IsDigit(symbol))
                {
                    int digit = symbol - '0';
                    digitCounts[digit]++;
                }
            }

            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Число {n} в степени {n} успешно вычислено.");
            resultBuilder.AppendLine($"Количество цифр в результате: {numberString.Length}");
            resultBuilder.AppendLine("Повторения цифр:");

            for (int i = 0; i <= 9; i++)
            {
                resultBuilder.AppendLine($"Цифра [{i}]: повторилась {digitCounts[i]} раз(а)");
            }

            tbResultData1.Text = resultBuilder.ToString();
        }
    }
}