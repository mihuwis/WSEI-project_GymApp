using GymApp.Context;
using GymApp.Models;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GymApp
{
    /// <summary>
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {

        private readonly BootstrapDB _database;

        public StatisticsPage(BootstrapDB database)
        {
            InitializeComponent();
            _database = database;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartDatePicker.SelectedDate.HasValue && EndDatePicker.SelectedDate.HasValue)
            {
                DateTime startDate = StartDatePicker.SelectedDate.Value;
                DateTime endDate = EndDatePicker.SelectedDate.Value;

                var filteredSessions = _database.Workouts
                    .Where(session => session.TimeStarted.Date >= startDate && session.TimeStarted.Date <= endDate)
                    .ToList();

                DisplayStatistics(filteredSessions);
            }
        }
        private void DisplayStatistics(List<WorkoutSession> sessions)
        {
            // Display the number of training sessions
            TrainingSessionsTextBlock.Text = $"Training Sessions: {sessions.Count}";

            // Display the total load per session and duration
            TotalLoadListBox.Items.Clear();
            var totalLoads = new List<double>();
            var sessionDurations = new List<double>();
            foreach (var session in sessions)
            {
                double totalLoad = session.ExerciseSets.Sum(set => set.Weight * set.Repetitions);
                double sessionDuration = (session.TimeFinished - session.TimeStarted).TotalMinutes;
                totalLoads.Add(totalLoad);
                sessionDurations.Add(sessionDuration);
                TotalLoadListBox.Items.Add($"Session on {session.TimeStarted.ToString("yyyy-MM-dd")}: {totalLoad} kg, Duration: {sessionDuration} min");
            }

            // Determine session with the biggest load
            var maxLoad = totalLoads.Max();
            var maxLoadIndex = totalLoads.IndexOf(maxLoad);
            if (maxLoadIndex >= 0)
            {
                var maxLoadSession = sessions[maxLoadIndex];
                BiggestLoadTextBlock.Text = $"{maxLoad} kg on {maxLoadSession.TimeStarted.ToString("yyyy-MM-dd")}";
            }

            // Determine session with the highest density (load per minute)
            var highestDensity = totalLoads.Zip(sessionDurations, (load, duration) => load / duration).Max();
            var highestDensityIndex = totalLoads.Zip(sessionDurations, (load, duration) => load / duration).ToList().IndexOf(highestDensity);
            if (highestDensityIndex >= 0)
            {
                var highestDensitySession = sessions[highestDensityIndex];
                HighestDensityTextBlock.Text = $"{highestDensity:F2} kg/min on {highestDensitySession.TimeStarted.ToString("yyyy-MM-dd")}";
            }

            // Display best results for each exercise
            var bestResults = new Dictionary<string, double>();
            foreach (var session in sessions)
            {
                foreach (var set in session.ExerciseSets)
                {
                    if (!bestResults.ContainsKey(set.Exercise.ExerciseName) || set.Weight > bestResults[set.Exercise.ExerciseName])
                    {
                        bestResults[set.Exercise.ExerciseName] = set.Weight;
                    }
                }
            }

            BestResultsListBox.Items.Clear();
            foreach (var result in bestResults)
            {
                BestResultsListBox.Items.Add($"{result.Key}: {result.Value} kg");
            }

            // Plot the chart
            PlotChart(sessions, totalLoads);
        }

        private void PlotChart(List<WorkoutSession> sessions, List<double> totalLoads)
        {
            ChartGrid.Children.Clear();

            var seriesCollection = new SeriesCollection();

            // Add column series for the number of sets
            var columnSeries = new ColumnSeries
            {
                Title = "Number of Sets",
                Values = new ChartValues<int>(sessions.Select(session => session.ExerciseSets.Count))
            };
            seriesCollection.Add(columnSeries);

            // Add line series for the total load
            var lineSeries = new LineSeries
            {
                Title = "Total Load (kg)",
                Values = new ChartValues<double>(totalLoads),
                PointGeometry = null,
                StrokeThickness = 2,
                Fill = Brushes.Transparent
            };
            seriesCollection.Add(lineSeries);

            var cartesianChart = new CartesianChart
            {
                Series = seriesCollection,
                AxisX = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Sessions",
                        Labels = sessions.Select(session => session.TimeStarted.ToString("yyyy-MM-dd")).ToArray()
                    }
                },
                AxisY = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Number of Sets"
                    },
                    new Axis
                    {
                        Title = "Total Load (kg)",
                        Position = AxisPosition.RightTop
                    }
                }
            };

            ChartGrid.Children.Add(cartesianChart);
        }

    }
}
