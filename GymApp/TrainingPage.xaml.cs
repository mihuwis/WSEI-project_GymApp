using GymApp.Context;
using GymApp.Models;
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
using System.Windows.Threading;

namespace GymApp
{
    /// <summary>
    /// Interaction logic for TrainingPage.xaml
    /// </summary>
    public partial class TrainingPage : Page
    {
        private BootstrapDB _database;
        private DispatcherTimer _timer;
        private DateTime _sessionStartTime;
        private List<ExerciseSet> _currentExerciseSets;
        public TrainingPage()
        {
            InitializeComponent();
            _database = new BootstrapDB();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _currentExerciseSets = new List<ExerciseSet>();
        }

        private void StartSessionButton_Click(object sender, RoutedEventArgs e)
        {
            _sessionStartTime = DateTime.Now;
            _timer.Start();
            TimerTextBlock.Text = "00:00:00";
            StartSessionButton.Visibility = Visibility.Collapsed;
        }
    }
}
