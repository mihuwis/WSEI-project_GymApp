using GymApp.Data;
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
using Microsoft.Extensions.DependencyInjection;

namespace GymApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GymAppContext _context;
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(IServiceProvider serviceProvider, GymAppContext context)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _context = context;
            NavigateToLogBookPage();
            TestDatabaseConnection(); // Dodajemy test odczytu danych
        }

        private void TrainingMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(_serviceProvider.GetRequiredService<TrainingPage>());
        }

        private void LogBookMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigateToLogBookPage();
        }

        private void StatisticsMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(_serviceProvider.GetRequiredService<StatisticsPage>());
        }

        private void NavigateToLogBookPage()
        {
            var logBookPage = _serviceProvider.GetRequiredService<LogBookPage>();
            logBookPage.LoadWorkoutSessions(); // reload powinien polecieć 
            MainFrame.Navigate(logBookPage);
        }

        private void TestDatabaseConnection()
        {
            var sessions = _context.WorkoutSessions.ToList();
            foreach (var session in sessions)
            {
                MessageBox.Show($"Session {session.WorkoutSessionId}: {session.TimeStarted} - {session.TimeFinished}");
            }
        }
    }
}