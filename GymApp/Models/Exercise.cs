using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        public string ExerciseName { get; set;}

        public TrainingEquipement TrainingEquipement { get; set; }

        public List<BodyPart> BodyParts { get; set; }

        public Exercise(int exerciseId, string exerciseName, 
            TrainingEquipement trainingEquipement, List<BodyPart> bodyParts)
        {
            ExerciseId = exerciseId;
            ExerciseName = exerciseName;
            TrainingEquipement = trainingEquipement;
            BodyParts = bodyParts;
        }
    }
}
