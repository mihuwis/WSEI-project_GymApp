using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public  class ExerciseSet
    {
        public int ExerciseSetId { get; set; }

        public Exercise Exercise { get; set; }

        public int Repetitions { get; set; }

        public float Weight { get; set; }

        public ExerciseSet() { }

        public ExerciseSet(int exerciseSetId, Exercise exerciseExecuted)
        {
            ExerciseSetId = exerciseSetId;
            Exercise = exerciseExecuted;
        }

        public ExerciseSet(int exerciseSetId, Exercise exerciseExecuted, int repetitions, float weight) : this(exerciseSetId, exerciseExecuted)
        {
            Repetitions = repetitions;
            Weight = weight;
        }
    }
}
