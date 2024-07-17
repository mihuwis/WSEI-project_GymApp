using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Context;
using Moq;
using GymApp.Models;


namespace GymApp.Tests
{
    [TestClass()]
    public class LogBookPageTests
    {
        private Mock<BootstrapDB> _mockDatabase;
        private LogBookPage _logBookPage;

        [TestInitialize]
        public void Setup()
        {
            // Mock the database
            _mockDatabase = new Mock<BootstrapDB>();

            // Setup fake workout data
            var fakeWorkouts = new List<WorkoutSession>
            {
                new WorkoutSession
                {
                    TimeStarted = DateTime.Now.AddDays(-1),
                    ExerciseSets = new List<ExerciseSet>
                    {
                        new ExerciseSet { Exercise = new Exercise { ExerciseName = "Squats" }, Weight = 100, Repetitions = 10 },
                        new ExerciseSet { Exercise = new Exercise { ExerciseName = "Bench Press" }, Weight = 80, Repetitions = 8 }
                    }
                },
                new WorkoutSession
                {
                    TimeStarted = DateTime.Now.AddDays(-2),
                    ExerciseSets = new List<ExerciseSet>
                    {
                        new ExerciseSet { Exercise = new Exercise { ExerciseName = "Deadlift" }, Weight = 120, Repetitions = 5 },
                    }
                }
            };

            _mockDatabase.Setup(db => db.Workouts).Returns(fakeWorkouts);

            // Create the LogBookPage instance with the mocked database
            _logBookPage = new LogBookPage(_mockDatabase.Object);
        }

        [TestMethod()]
        public void LoadWorkoutSessionsTest()
        {
            Assert.Fail();
        }
    }
}