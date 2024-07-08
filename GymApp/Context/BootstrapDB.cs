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
            TrainingEquipements = new List<TrainingEquipement>()
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
                new Exercise(7, "Dead Lift", TrainingEquipements[0], new List<BodyPart> { BodyParts[2], BodyParts[4] }),
            };


            WorkoutSession session001 = new WorkoutSession()
            {
                WorkoutSessionId = 1,
                TimeStarted = new DateTime(2023, 8, 29, 19, 27, 15, 18),
                TimeFinished = new DateTime(2023, 8, 29, 19, 47, 18, 28)
            };
            // Bench press 2 set
            session001.ExerciseSets.Add(new ExerciseSet(1, Exercises[0], 12, 54));
            session001.ExerciseSets.Add(new ExerciseSet(2, Exercises[0], 10, 54));

            // SQ 3 set
            session001.ExerciseSets.Add(new ExerciseSet(3, Exercises[2], 6, 74));
            session001.ExerciseSets.Add(new ExerciseSet(4, Exercises[2], 2, 94));
            session001.ExerciseSets.Add(new ExerciseSet(5, Exercises[2], 5, 74));

            // Dead Lift 2 set
            session001.ExerciseSets.Add(new ExerciseSet(6, Exercises[6], 5, 104));
            session001.ExerciseSets.Add(new ExerciseSet(7, Exercises[6], 5, 104));
        }
    }
}
