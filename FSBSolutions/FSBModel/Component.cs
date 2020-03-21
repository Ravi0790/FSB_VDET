using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Component
    {
        public int ComponentId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Component Name", Description = "Component Name")]
        public string ComponentName { get; set; }

        //[Display(Name = "Benutzername", Description = "UserType")]
        //public int UserTypeId { get; set; }
        //public virtual UserType UserType { get; set; }

        //[Display(Name = "Zeilenname", Description = "Line Name")]
        //public int LineId { get; set; }
        //public virtual Line Line { get; set; }
        

        [Display(Name = "Module Name", Description = "Module Name")]
        public int ModuleId { get; set; }
        public Module Module { get; set; }

        public IList<Part> Parts { get; set; }

        public bool Status { get; set; }

    }
}
