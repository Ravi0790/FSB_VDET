using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Reason
    {
        public int ReasonId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Name des Grundes", Description = "Reason Name")]
        public string ReasonName { get; set; }

        [Display(Name = "VerlustartName", Description = "Verlustart Name")]
        public int VerlustartId { get; set; }

        public virtual Verlustart Verlustart { get; set; }

        public bool Status { get; set; }
    }
}
