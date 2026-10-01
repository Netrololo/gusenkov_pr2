using System;
using System.Data;
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
    public partial class Task5Page : Page
    {
        public Task5Page() { InitializeComponent(); }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(tbRows.Text, out int rows) || !int.TryParse(tbCols.Text, out int cols) || rows < 1 || cols < 1)
            {
                MessageBox.Show("Введите корректные размеры матрицы (числа > 0).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int[,] matrix = new int[rows, cols];
            Random rand = new Random();

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = rand.Next(-10, 11);

            int[] flatArray = new int[rows * cols];
            int index = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    flatArray[index++] = matrix[i, j];

            int minVal = flatArray.Min();
            int maxVal = flatArray.Max();
            txtExtremums.Text = $"Минимальный элемент: {minVal} | Максимальный элемент: {maxVal}";

            int[] ascArray = flatArray.OrderBy(x => x).ToArray();
            int[] descArray = flatArray.OrderByDescending(x => x).ToArray();

            dgOriginal.ItemsSource = CreateDataTable(matrix, rows, cols).DefaultView;
            dgAsc.ItemsSource = CreateDataTableFromFlat(ascArray, rows, cols).DefaultView;
            dgDesc.ItemsSource = CreateDataTableFromFlat(descArray, rows, cols).DefaultView;
        }

        private DataTable CreateDataTable(int[,] sourceMatrix, int r, int c)
        {
            DataTable dt = new DataTable();
            for (int j = 0; j < c; j++) dt.Columns.Add();
            for (int i = 0; i < r; i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < c; j++) row[j] = sourceMatrix[i, j];
                dt.Rows.Add(row);
            }
            return dt;
        }

        private DataTable CreateDataTableFromFlat(int[] flat, int r, int c)
        {
            DataTable dt = new DataTable();
            for (int j = 0; j < c; j++) dt.Columns.Add();
            int idx = 0;
            for (int i = 0; i < r; i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < c; j++) row[j] = flat[idx++];
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}