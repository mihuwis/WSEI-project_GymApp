using GymApp.Context;
using System.Text;
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
        private BootstrapDB _databaseFake;
        public MainWindow()
        {
            InitializeComponent();
            _databaseFake = new BootstrapDB();
            LoadWorkoutSessions();
        }

        private void LoadWorkoutSessions()
        {
            foreach(var sessions in _databaseFake.Workouts)
            {
                var sessionPanel = new StackPanel
                {
                    Background = Brushes.LightGreen,
                    Margin = new Thickness(0, 5, 0, 5)
                };
            }
        }
    }
}