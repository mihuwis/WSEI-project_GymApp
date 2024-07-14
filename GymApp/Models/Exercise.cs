using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GymApp.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        public string ExerciseName { get; set;}

        public TrainingEquipement TrainingEquipement { get; set; }

        [NotMapped]
        public List<BodyPart> BodyParts { get; set; }

        public Exercise() { }

        public Exercise(int exerciseId, string exerciseName, 
            TrainingEquipement trainingEquipement, List<BodyPart> bodyParts)
        {
            ExerciseId = exerciseId;
            ExerciseName = exerciseName;
            TrainingEquipement = trainingEquipement;
            BodyParts = bodyParts;
        }

        public Exercise(int exerciseId, string exerciseName, int trainingEquipementId, List<int> bodyPartIds)
        {
            ExerciseId = exerciseId;
            ExerciseName = exerciseName;
            TrainingEquipement = new TrainingEquipement { EquipementID = trainingEquipementId };
            BodyParts = new List<BodyPart>();
            foreach (var id in bodyPartIds)
            {
                BodyParts.Add(new BodyPart { BodyPartID = id });
            }
        }
    }
}
