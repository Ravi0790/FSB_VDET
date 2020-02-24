using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Part
    {
        public int PartId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Teilname", Description = "Part Name")]
        public string PartName { get; set; }


        //[Display(Name = "Benutzername", Description = "UserType")]
        //public int UserTypeId { get; set; }
        //public virtual UserType UserType { get; set; }

        //[Display(Name = "Zeilenname", Description = "Line Name")]
        //public int LineId { get; set; }
        //public virtual Line Line { get; set; }


        [Display(Name = "Komponentenname", Description = "Component Name")]
        public int ComponentId { get; set; }        
        public virtual Component Component { get; set; }

        public bool Status { get; set; }
    }
}
