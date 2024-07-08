using GymApp.Context;
using System.Text;
using GymApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GymApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LogBookPage());
        }


        private void TrainingMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TrainingPage());
        }

        private void LogBookMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LogBookPage());
        }

        private void StatisticsMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StatisticsPage());
        }


    
    }
}