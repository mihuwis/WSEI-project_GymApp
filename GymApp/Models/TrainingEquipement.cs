using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Models
{
    public class TrainingEquipement
    {
        [Key]
        public int EquipementID { get; set; }
        [Required]
        public string EquipementName { get; set; }

        public TrainingEquipement() { }

        public TrainingEquipement(int id, string equipementName)
        {
            EquipementID = id;
            EquipementName = equipementName;
        }
    }
}
