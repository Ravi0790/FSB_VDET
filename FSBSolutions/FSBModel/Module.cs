using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Module
    {
        public int ModuleId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Modulname", Description = "Module Name")]
        public string ModuleName { get; set; }

        [Display(Name = "Maschinenname", Description = "Machine Name")]
        public int MachineId { get; set; }

        public virtual Machine Machine { get; set; }

        public bool Status { get; set; }

        public IList<Component> Components { get; set; }
    }
}
