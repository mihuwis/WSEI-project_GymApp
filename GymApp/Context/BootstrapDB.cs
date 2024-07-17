using GymApp.Models;
using System;
using System.Collections.Generic;

namespace GymApp.Context
{
    public class BootstrapDB
    {
        public virtual List<WorkoutSession> Workouts { get; set; }
        public List<TrainingEquipement> TrainingEquipements { get; set; }
        public List<BodyPart> BodyParts { get; set; }
        public List<Exercise> Exercises { get; set; }

        public BootstrapDB()
        {
            TrainingEquipements = new List<TrainingEquipement>
            {
                new TrainingEquipement(1, "Barbell"),
                new TrainingEquipement(2, "Dumbell"),
                new TrainingEquipement(3, "Kettlebell"),
                new TrainingEquipement(4, "Resistance Band")
            };

            BodyParts = new List<BodyPart>
            {
                new BodyPart(1, "Shoulders"),
                new BodyPart(2, "Chest"),
                new BodyPart(3, "Back"),
                new BodyPart(4, "Abs"),
                new BodyPart(5, "Glutes"),
                new BodyPart(6, "Quads"),
                new BodyPart(7, "Biceps"),
                new BodyPart(8, "Triceps")
            };

            Exercises = new List<Exercise>
            {
                new Exercise(1, "Bench Press", TrainingEquipements[0], new List<BodyPart> { BodyParts[1] }),
                new Exercise(2, "Bench Press with dumbells", TrainingEquipements[1], new List<BodyPart> { BodyParts[1] }),
                new Exercise(3, "Squat", TrainingEquipements[0], new List<BodyPart> { BodyParts[4], BodyParts[5] }),
                new Exercise(4, "Bend Over Row w/ dumbells", TrainingEquipements[1], new List<BodyPart> { BodyParts[2] }),
                new Exercise(5, "Biceps curl w/ dumbells", TrainingEquipements[1], new List<BodyPart> { BodyParts[6] }),
                new Exercise(6, "Triceps pull downs w/ band", TrainingEquipements[3], new List<BodyPart> { BodyParts[7] }),
                new Exercise(7, "Dead Lift", TrainingEquipements[0], new List<BodyPart> { BodyParts[2], BodyParts[4] })
            };

            Workouts = new List<WorkoutSession>
            {
                new WorkoutSession
                {
                    WorkoutSessionId = 1,
                    TimeStarted = new DateTime(2024, 5, 1, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 5, 1, 19, 0, 0),
                    ExerciseSets = new List<ExerciseSet>
                    {
                        new ExerciseSet(1, Exercises[0], 10, 100),
                        new ExerciseSet(2, Exercises[0], 8, 90),
                        new ExerciseSet(3, Exercises[0], 6, 85),
                        new ExerciseSet(4, Exercises[6], 12, 120),
                        new ExerciseSet(5, Exercises[6], 10, 110),
                        new ExerciseSet(6, Exercises[6], 8, 100),
                        new ExerciseSet(7, Exercises[3], 10, 60),
                        new ExerciseSet(8, Exercises[3], 12, 55),
                        new ExerciseSet(9, Exercises[2], 15, 80),
                        new ExerciseSet(10, Exercises[2], 12, 70),
                        new ExerciseSet(11, Exercises[5], 10, 30),
                        new ExerciseSet(12, Exercises[5], 8, 25)
                    }
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 2,
                    TimeStarted = new DateTime(2024, 5, 10, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 5, 10, 19, 0, 0),
                    ExerciseSets = new List<ExerciseSet>
                    {
                        new ExerciseSet(13, Exercises[0], 12, 95),
                        new ExerciseSet(14, Exercises[0], 10, 85),
                        new ExerciseSet(15, Exercises[0], 8, 80),
                        new ExerciseSet(16, Exercises[6], 14, 125),
                        new ExerciseSet(17, Exercises[6], 12, 115),
                        new ExerciseSet(18, Exercises[6], 10, 105),
                        new ExerciseSet(19, Exercises[4], 12, 40),
                        new ExerciseSet(20, Exercises[4], 10, 35),
                        new ExerciseSet(21, Exercises[2], 15, 75),
                        new ExerciseSet(22, Exercises[2], 12, 65),
                        new ExerciseSet(23, Exercises[5], 10, 30),
                        new ExerciseSet(24, Exercises[5], 8, 25)
                    }
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 3,
                    TimeStarted = new DateTime(2024, 5, 20, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 5, 20, 19, 0, 0),
                    ExerciseSets = new List<ExerciseSet>
                    {
                        new ExerciseSet(25, Exercises[1], 10, 50),
                        new ExerciseSet(26, Exercises[1], 8, 45),
                        new ExerciseSet(27, Exercises[1], 6, 40),
                        new ExerciseSet(28, Exercises[6], 12, 130),
                        new ExerciseSet(29, Exercises[6], 10, 120),
                        new ExerciseSet(30, Exercises[6], 8, 110),
                        new ExerciseSet(31, Exercises[4], 15, 35),
                        new ExerciseSet(32, Exercises[4], 12, 30),
                        new ExerciseSet(33, Exercises[2], 18, 70),
                        new ExerciseSet(34, Exercises[2], 15, 60),
                        new ExerciseSet(35, Exercises[5], 12, 25),
                        new ExerciseSet(36, Exercises[5], 10, 20)
                    }
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 4,
                    TimeStarted = new DateTime(2024, 6, 5, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 6, 5, 19, 0, 0),
                    ExerciseSets = new List<ExerciseSet>
                    {
                        new ExerciseSet(37, Exercises[3], 10, 60),
                        new ExerciseSet(38, Exercises[3], 12, 55),
                        new ExerciseSet(39, Exercises[3], 14, 50),
                        new ExerciseSet(40, Exercises[0], 12, 95),
                        new ExerciseSet(41, Exercises[0], 10, 85),
                        new ExerciseSet(42, Exercises[0], 8, 80),
                        new ExerciseSet(43, Exercises[2], 20, 75),
                        new ExerciseSet(44, Exercises[2], 18, 70),
                        new ExerciseSet(45, Exercises[6], 12, 125),
                        new ExerciseSet(46, Exercises[6], 10, 120),
                        new ExerciseSet(47, Exercises[5], 12, 35),
                        new ExerciseSet(48, Exercises[5], 10, 30)
                    }
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 5,
                    TimeStarted = new DateTime(2024, 6, 15, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 6, 15, 19, 0, 0),
                    ExerciseSets = new List<ExerciseSet>
                    {
                        new ExerciseSet(49, Exercises[4], 15, 40),
                        new ExerciseSet(50, Exercises[4], 12, 35),
                        new ExerciseSet(51, Exercises[4], 10, 30),
                        new ExerciseSet(52, Exercises[1], 12, 55),
                        new ExerciseSet(53, Exercises[1], 10, 50),
                        new ExerciseSet(54, Exercises[1], 8, 45),
                        new ExerciseSet(55, Exercises[2], 20, 70),
                        new ExerciseSet(56, Exercises[2], 18, 65),
                        new ExerciseSet(57, Exercises[6], 15, 130),
                        new ExerciseSet(58, Exercises[6], 12, 125),
                        new ExerciseSet(59, Exercises[5], 10, 30),
                        new ExerciseSet(60, Exercises[5], 8, 25)
                    }
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 6,
                    TimeStarted = new DateTime(2024, 6, 25, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 6, 25, 19, 0, 0),
                    ExerciseSets = new List<ExerciseSet>
                    {
                        new ExerciseSet(61, Exercises[0], 10, 100),
                        new ExerciseSet(62, Exercises[0], 8, 90),
                        new ExerciseSet(63, Exercises[0], 6, 85),
                        new ExerciseSet(64, Exercises[6], 12, 120),
                        new ExerciseSet(65, Exercises[6], 10, 110),
                        new ExerciseSet(66, Exercises[6], 8, 100),
                        new ExerciseSet(67, Exercises[3], 10, 60),
                        new ExerciseSet(68, Exercises[3], 12, 55),
                        new ExerciseSet(69, Exercises[2], 15, 80),
                        new ExerciseSet(70, Exercises[2], 12, 70),
                        new ExerciseSet(71, Exercises[5], 10, 30),
                        new ExerciseSet(72, Exercises[5], 8, 25)
                    }
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 7,
                    TimeStarted = new DateTime(2024, 7, 5, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 7, 5, 19, 0, 0),
                    ExerciseSets = new List<ExerciseSet>
                    {
                        new ExerciseSet(73, Exercises[2], 20, 75),
                        new ExerciseSet(74, Exercises[2], 18, 70),
                        new ExerciseSet(75, Exercises[2], 16, 65),
                        new ExerciseSet(76, Exercises[0], 10, 100),
                        new ExerciseSet(77, Exercises[0], 8, 90),
                        new ExerciseSet(78, Exercises[0], 6, 85),
                        new ExerciseSet(79, Exercises[1], 10, 60),
                        new ExerciseSet(80, Exercises[1], 12, 55),
                        new ExerciseSet(81, Exercises[4], 15, 50),
                        new ExerciseSet(82, Exercises[4], 12, 45),
                        new ExerciseSet(83, Exercises[6], 15, 130),
                        new ExerciseSet(84, Exercises[6], 12, 125)
                    }
                },
                new WorkoutSession
                {
                    WorkoutSessionId = 8,
                    TimeStarted = new DateTime(2024, 7, 15, 18, 0, 0),
                    TimeFinished = new DateTime(2024, 7, 15, 19, 0, 0),
                    ExerciseSets = new List<ExerciseSet>
                    {
                        new ExerciseSet(85, Exercises[5], 10, 40),
                        new ExerciseSet(86, Exercises[5], 8, 35),
                        new ExerciseSet(87, Exercises[5], 6, 30),
                        new ExerciseSet(88, Exercises[6], 14, 140),
                        new ExerciseSet(89, Exercises[6], 12, 130),
                        new ExerciseSet(90, Exercises[6], 10, 120),
                        new ExerciseSet(91, Exercises[3], 10, 70),
                        new ExerciseSet(92, Exercises[3], 12, 65),
                        new ExerciseSet(93, Exercises[2], 20, 85),
                        new ExerciseSet(94, Exercises[2], 18, 80),
                        new ExerciseSet(95, Exercises[0], 12, 95),
                        new ExerciseSet(96, Exercises[0], 10, 90)
                    }
                }
            };
        }
    }
}
