using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Models
{
    public class BodyPart
    {
        [Key]
        public int BodyPartID { get; set; }
        
        public string BodyPartName { get; set;}

        public BodyPart(int bodyPartID, string bodyPartName)
        {
            BodyPartID = bodyPartID;
            BodyPartName = bodyPartName;
        }
    }
}
