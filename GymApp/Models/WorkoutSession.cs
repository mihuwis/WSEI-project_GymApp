using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class WorkoutSession
    {
        public int WorkoutSessionId { get; set; }

        public DateTime TimeStarted { get; set; }

        public DateTime TimeFinished { get; set; }

        public List<ExerciseSet> ExerciseSets { get; set; }


    }
}
