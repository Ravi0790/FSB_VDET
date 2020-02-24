using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Machine
    {
        public int MachineId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Maschinenname", Description = "Machine Name")]
        public string MachineName { get; set; }
        public bool Status { get; set; }

        //[Display(Name = "Benutzername", Description = "UserType")]
        //public int UserTypeId { get; set; }
        //public virtual UserType UserType { get; set; }

        //[Display(Name = "Zeilenname", Description = "Line Name")]
        //public int LineId { get; set; }
        //public virtual Line Line { get; set; }

        [Display(Name = "Standortnamen", Description = "Location Name")]
        public int LocationId { get; set; }        
        public virtual Location Location { get; set; }

        public IList<Module> Modules { get; set; }

    }
}
