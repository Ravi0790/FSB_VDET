using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Location
    {
        public int LocationId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Standortnamen", Description = "Location Name")]
        public string LocationName { get; set; }
        public bool Status { get; set; }

        [Display(Name = "Zeilenname", Description = "Line Name")]
        public int LineId { get; set; }
        public virtual Line Line { get; set; }

        [Display(Name = "Benutzername", Description = "UserType Name")]
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        public IList<Machine> Machines { get; set; }
    }
}
