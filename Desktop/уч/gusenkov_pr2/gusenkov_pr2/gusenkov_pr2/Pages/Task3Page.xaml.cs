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
    public partial class Task3Page : Page
    {
        public Task3Page() { InitializeComponent(); }

        private void btnProcess3_Click(object sender, RoutedEventArgs e)
        {
            string rawInput = tbInputArray3.Text;
            if (string.IsNullOrWhiteSpace(rawInput))
            {
                MessageBox.Show("Введите массив чисел!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                int[] array = rawInput.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse).ToArray();

                if (array.Length == 0) return;

                var maxDuplicates = array.GroupBy(x => x)
                                         .Select(g => new { Element = g.Key, Count = g.Count() })
                                         .OrderByDescending(g => g.Count)
                                         .FirstOrDefault();

                tbResult3.Text = $"Всего элементов: {array.Length}\n" +
                                 $"Чаще всего встречается элемент: {maxDuplicates.Element}\n" +
                                 $"Максимальное количество одинаковых элементов: {maxDuplicates.Count}";
            }
            catch
            {
                MessageBox.Show("Ошибка валидации! Убедитесь, что ввели только целые числа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}