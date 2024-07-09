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

        public TrainingPage(BootstrapDB database)
        {
            InitializeComponent();
            _database = database;
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
            AddMoreSetsButton.Visibility = Visibility.Visible;
            StopSessionButton.Visibility = Visibility.Visible;
            ExerciseSetsPanel.Visibility = Visibility.Visible;
            AddExerciseSetControl();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var actualTimeOfSession = DateTime.Now - _sessionStartTime;
            TimerTextBlock.Text = actualTimeOfSession.ToString(@"hh\:mm\:ss");
        }

        private void AddMoreSetsButton_Click(object sender, RoutedEventArgs e)
        {
            AddExerciseSetControl();
        }

        private void StopSessionButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            var sessionEndTime = DateTime.Now;
            var workoutSession = new WorkoutSession
            {
                WorkoutSessionId = _database.Workouts.Count + 1,
                TimeStarted = _sessionStartTime,
                TimeFinished = sessionEndTime,
                ExerciseSets = _currentExerciseSets
            };
            _database.Workouts.Add(workoutSession);
            MessageBox.Show("Training session saved!");

            // Reset UI
            StartSessionButton.Visibility = Visibility.Visible;
            AddMoreSetsButton.Visibility = Visibility.Collapsed;
            StopSessionButton.Visibility = Visibility.Collapsed;
            ExerciseSetsPanel.Visibility = Visibility.Collapsed;
            ExerciseSetsPanel.Children.Clear();
            TimerTextBlock.Text = string.Empty;
            _currentExerciseSets.Clear();
        }

        private void AddExerciseSetControl()
        {
            var exerciseSetPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5) };

            var exerciseComboBox = new ComboBox
            {
                Width = 150,
                ItemsSource = _database.Exercises,
                DisplayMemberPath = "ExerciseName"
            };
            exerciseSetPanel.Children.Add(exerciseComboBox);

            var weightTextBox = new TextBox
            {
                Width = 50,
                Margin = new Thickness(5, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
            exerciseSetPanel.Children.Add(weightTextBox);

            var repetitionsTextBox = new TextBox
            {
                Width = 50,
                Margin = new Thickness(5, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
            exerciseSetPanel.Children.Add(repetitionsTextBox);

            exerciseSetPanel.Children.Add(new Button
            {
                Content = "Save",
                Margin = new Thickness(5, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                Tag = new Action(() =>
                {
                    var selectedExercise = (Exercise)exerciseComboBox.SelectedItem;
                    if (selectedExercise != null &&
                        int.TryParse(weightTextBox.Text, out var weight) &&
                        int.TryParse(repetitionsTextBox.Text, out var repetitions))
                    {
                        _currentExerciseSets.Add(new ExerciseSet(_currentExerciseSets.Count + 1, selectedExercise, repetitions, weight));
                        exerciseComboBox.IsEnabled = false;
                        weightTextBox.IsEnabled = false;
                        repetitionsTextBox.IsEnabled = false;
                    }
                })
            });

            ExerciseSetsPanel.Children.Add(exerciseSetPanel);
        }
    }
}
