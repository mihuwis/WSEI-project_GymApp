using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GymApp.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        public string ExerciseName { get; set; }

        public int TrainingEquipementId { get; set; }

        [ForeignKey("TrainingEquipementId")]
        public TrainingEquipement TrainingEquipement { get; set; }

        [NotMapped]
        public List<BodyPart> BodyParts { get; set; }

        public Exercise() { }

        public Exercise(int exerciseId, string exerciseName, int trainingEquipementId, List<BodyPart> bodyParts)
        {
            ExerciseId = exerciseId;
            ExerciseName = exerciseName;
            TrainingEquipementId = trainingEquipementId;
            BodyParts = bodyParts;
        }

        public Exercise(int exerciseId, string exerciseName, int trainingEquipementId, List<int> bodyPartIds)
        {
            ExerciseId = exerciseId;
            ExerciseName = exerciseName;
            TrainingEquipementId = trainingEquipementId;
            BodyParts = new List<BodyPart>();
            foreach (var id in bodyPartIds)
            {
                BodyParts.Add(new BodyPart { BodyPartID = id });
            }
        }
    }
}
