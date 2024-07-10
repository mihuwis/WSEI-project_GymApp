using GymApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Context
{
    public class BootstrapDB
    {
        public List<WorkoutSession> Workouts { get; set; }
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
                    TimeStarted = new DateTime(2023, 8, 29, 19, 27, 15, 18),
                    TimeFinished = new DateTime(2023, 8, 29, 19, 47, 18, 28),
                    ExerciseSets = new List<ExerciseSet>
                    {
                        new ExerciseSet(1, Exercises[0], 10, 100),
                        new ExerciseSet(2, Exercises[1], 8, 50)
                    }
                }
            };
        }
    }
   
}
