using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class TrainingEquipement
    {
        public int EquipementID { get; set; }
        public string EquipementName { get; set; }

        public TrainingEquipement() { }
        public TrainingEquipement(int id, string equipementName)
        {
            EquipementID = id;
            EquipementName = equipementName;
        }
    }
}
