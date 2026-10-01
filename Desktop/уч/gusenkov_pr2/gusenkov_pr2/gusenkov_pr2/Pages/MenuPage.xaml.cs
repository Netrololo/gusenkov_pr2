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
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void btnOpenTask1_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FrmMain.Navigate(new Task1Page());
        }

        private void btnOpenTask2_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FrmMain.Navigate(new Task2Page());
        }

        private void btnOpenTask3_Click(object sender, RoutedEventArgs e) =>
    ((MainWindow)Application.Current.MainWindow).FrmMain.Navigate(new Task3Page());

        private void btnOpenTask4_Click(object sender, RoutedEventArgs e) =>
            ((MainWindow)Application.Current.MainWindow).FrmMain.Navigate(new Task4Page());

        private void btnOpenTask5_Click(object sender, RoutedEventArgs e) =>
            ((MainWindow)Application.Current.MainWindow).FrmMain.Navigate(new Task5Page());

    }
}