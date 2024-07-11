﻿using GymApp.Context;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GymApp
{
    public partial class LogBookPage : Page
    {
        private readonly BootstrapDB _database;

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
                    MaxWidth = 600,
                    Margin = new Thickness(0, 5, 0, 5),
                    Background = new LinearGradientBrush(
                        Colors.LightGreen,
                        Colors.White,
                        new Point(0, 0),
                        new Point(1, 0)) // Gradient z lewej do prawej 
                };

                var sessionHeader = new TextBlock
                {
                    Text = $"Training: {session.TimeStarted.ToString("yyyy-MM-dd HH:mm")}", 
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(5)
                };
                sessionPanel.Children.Add(sessionHeader);

                var exercisesPanel = new StackPanel
                {
                    Visibility = Visibility.Collapsed
                };

                foreach (var exerciseSet in session.ExerciseSets)
                {
                    var exerciseText = new TextBlock
                    {
                        Text = $"{exerciseSet.Exercise.ExerciseName} - {exerciseSet.Weight}kg x {exerciseSet.Repetitions} reps",
                        Margin = new Thickness(10, 0, 0, 0)
                    };
                    exercisesPanel.Children.Add(exerciseText);
                }

                sessionPanel.Children.Add(exercisesPanel);

                sessionPanel.MouseLeftButtonUp += (sender, e) =>
                {
                    exercisesPanel.Visibility = exercisesPanel.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
                };

                WorkoutSessionsPanel.Children.Add(sessionPanel);
            }
        }
    }

}
