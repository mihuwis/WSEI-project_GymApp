using GymApp.Context;
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

namespace GymApp
{
    /// <summary>
    /// Interaction logic for LogBookPage.xaml
    /// </summary>
    public partial class LogBookPage : Page
    {
        private BootstrapDB _database;
        public LogBookPage(BootstrapDB database)
        {
            InitializeComponent();
            _database = database;
            LoadWorkoutSessions();
        }

        public void LoadWorkoutSessions()
        {
            WorkoutSessionsPanel.Children.Clear();
            foreach (var session in _database.Workouts)
            {
                var sessionPanel = new StackPanel
                {
                    Background = Brushes.LightGreen,
                    Margin = new Thickness(0, 5, 0, 5)
                };

                var sessionHeader = new TextBlock
                {
                    Text = session.TimeStarted.ToString("yyyy-MM-dd"),
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(5)
                };
                sessionPanel.Children.Add(sessionHeader);

                var exercisePanel = new StackPanel
                {
                    Visibility = Visibility.Collapsed,
                };

                foreach (var exerciseSet in session.ExerciseSets)
                {
                    var exerciseText = new TextBlock
                    {
                        Text = $"{exerciseSet.ExerciseExecuted.ExerciseName} - " +
                        $"{exerciseSet.Weight}kg x " +
                        $"{exerciseSet.Repetitions} reps",
                        Margin = new Thickness(10, 0, 0, 0)
                    };
                    exercisePanel.Children.Add(exerciseText);
                }

                sessionPanel.Children.Add(exercisePanel);

                sessionPanel.MouseLeftButtonUp += (sender, e) =>
                {
                    exercisePanel.Visibility = exercisePanel.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
                };


                WorkoutSessionsPanel.Children.Add(sessionPanel);
            }
        }
    }
}
