using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    /***********This is WasteCategory/breakdown****************/
    public class Verlustart
    {
        public int VerlustartId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "VerlustartName", Description = "Verlustart Name")]
        public string VerlustartName { get; set; }

        //[Display(Name = "Benutzername", Description = "UserType Name")] 
        //public int UserTypeId { get; set; }

        //public UserType UserType { get; set; }


        public int PlantId { get; set; }

        public Plant Plant { get; set; }

        public bool Status { get; set; }
        public IList<Reason> Reasons { get; set; }
    }
}
