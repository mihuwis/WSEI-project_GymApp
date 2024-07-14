﻿using GymApp.Data;
using Microsoft.EntityFrameworkCore;
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
        private readonly GymAppContext _context;

        public LogBookPage(GymAppContext context)
        {
            InitializeComponent();
            _context = context;
            var connectionString = context.Database.GetDbConnection().ConnectionString;
            MessageBox.Show($"Database Path: {connectionString}");
            LoadWorkoutSessions();
        }

        public void LoadWorkoutSessions()
        {
            WorkoutSessionsPanel.Children.Clear();

            // Testowanie zapytania bez Include
            var workoutSessions = _context.WorkoutSessions.ToList();
            if (workoutSessions == null || workoutSessions.Count == 0)
            {
                MessageBox.Show("No workout sessions found.");
                return;
            }

            MessageBox.Show($"Found {workoutSessions.Count} workout sessions.");

            var sessions = _context.WorkoutSessions
                .Include(ws => ws.ExerciseSets)
                .ThenInclude(es => es.Exercise)
                .ToList();

            foreach (var session in sessions)
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
