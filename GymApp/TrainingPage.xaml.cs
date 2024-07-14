using GymApp.Data;
using GymApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace GymApp
{


    public partial class TrainingPage : Page
    {
        private readonly GymAppContext _context;
        private DispatcherTimer _timer;
        private DateTime _sessionStartTime;
        private List<ExerciseSet> _currentExerciseSets;

        public TrainingPage(GymAppContext context)
        {
            InitializeComponent();
            _context = context;
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
            var elapsed = DateTime.Now - _sessionStartTime;
            TimerTextBlock.Text = elapsed.ToString(@"hh\:mm\:ss");
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
                TimeStarted = _sessionStartTime,
                TimeFinished = sessionEndTime,
                ExerciseSets = new List<ExerciseSet>(_currentExerciseSets) 
            };

            _context.WorkoutSessions.Add(workoutSession);
            _context.SaveChanges();
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
                ItemsSource = _context.Exercises.ToList(),
                DisplayMemberPath = "ExerciseName"
            };
            exerciseSetPanel.Children.Add(exerciseComboBox);

            var weightLabel = new TextBlock
            {
                Text = "Weight:",
                VerticalAlignment = VerticalAlignment.Center
            };
            exerciseSetPanel.Children.Add(weightLabel);

            var weightTextBox = new TextBox
            {
                Width = 50,
                Margin = new Thickness(5, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
            exerciseSetPanel.Children.Add(weightTextBox);

            var repsLabel = new TextBlock
            {
                Text = "reps:",
                VerticalAlignment = VerticalAlignment.Center
            };
            exerciseSetPanel.Children.Add(repsLabel);

            var repetitionsTextBox = new TextBox
            {
                Width = 50,
                Margin = new Thickness(5, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
            exerciseSetPanel.Children.Add(repetitionsTextBox);

            var saveButton = new Button
            {
                Content = "Save",
                Margin = new Thickness(5, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center
            };

            var errorTextBlock = new TextBlock
            {
                Foreground = Brushes.Red,
                Visibility = Visibility.Collapsed
            };
            exerciseSetPanel.Children.Add(errorTextBlock);

            saveButton.Click += (s, e) =>
            {
                errorTextBlock.Visibility = Visibility.Collapsed;
                var selectedExercise = (Exercise)exerciseComboBox.SelectedItem;
                if (selectedExercise != null &&
                    int.TryParse(weightTextBox.Text, out var weight) &&
                    int.TryParse(repetitionsTextBox.Text, out var repetitions))
                {
                    _currentExerciseSets.Add(new ExerciseSet
                    {
                        Exercise = selectedExercise,
                        Weight = weight,
                        Repetitions = repetitions
                    });
                    exerciseComboBox.IsEnabled = false;
                    weightTextBox.IsEnabled = false;
                    repetitionsTextBox.IsEnabled = false;
                    saveButton.IsEnabled = false;
                }
                else
                {
                    errorTextBlock.Text = "Value must be a number";
                    errorTextBlock.Visibility = Visibility.Visible;
                }
            };

            exerciseSetPanel.Children.Add(saveButton);

            ExerciseSetsPanel.Children.Add(exerciseSetPanel);
        }
    }
}
