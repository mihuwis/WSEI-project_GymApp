using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Models
{
    public  class ExerciseSet
    {
        [Key]
        public int ExerciseSetId { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public int Repetitions { get; set; }

        public float Weight { get; set; }

        public int WorkoutSessionId { get; set; }
        public WorkoutSession WorkoutSession { get; set; }

        public ExerciseSet() { }

        public ExerciseSet(int exerciseSetId, int exerciseId, int workoutSessionId, int repetitions, float weight)
        {
            ExerciseSetId = exerciseSetId;
            ExerciseId = exerciseId;
            WorkoutSessionId = workoutSessionId;
            Repetitions = repetitions;
            Weight = weight;
        }
    }
}
