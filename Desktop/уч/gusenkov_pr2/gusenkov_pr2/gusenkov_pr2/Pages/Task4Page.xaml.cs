using System;
using System.Collections.Generic;
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
    public partial class Task4Page : Page
    {
        public Task4Page() { InitializeComponent(); }

        private void btnProcess4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] array = tbInputArray4.Text.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse).ToArray();

                var sorted = array.OrderByDescending(x => x).ToList();
                List<int> part1 = new List<int>();
                List<int> part2 = new List<int>();

                long sum1 = 0, sum2 = 0;

                foreach (var item in sorted)
                {
                    if (sum1 <= sum2) { part1.Add(item); sum1 += item; }
                    else { part2.Add(item); sum2 += item; }
                }

                double ratio = sum1 >= sum2 ? (double)sum1 / sum2 : (double)sum2 / sum1;

                if (ratio <= 1.5)
                {
                    int[] resultArr = part1.Concat(part2).ToArray();

                    tbResult4.Text = $"Часть 1: {string.Join(", ", part1)} (Сумма: {sum1})\n" +
                                     $"Часть 2: {string.Join(", ", part2)} (Сумма: {sum2})\n" +
                                     $"Соотношение сумм: {ratio:F2}\n" +
                                     $"Итоговый переставленный массив:\n{string.Join(" ", resultArr)}";
                }
                else
                {
                    tbResult4.Text = "Разделить массив с условием отличия сумм не более чем в 1.5 раза невозможно.";
                }
            }
            catch
            {
                MessageBox.Show("Ошибка валидации элементов массива.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}