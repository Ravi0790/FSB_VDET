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
        [Display(Name = "Komponentenname", Description = "Component Name")]
        public string ComponentName { get; set; }
        public bool Status { get; set; }

        [Display(Name = "Modulname", Description = "Module Name")]
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public IList<Part> Parts { get; set; }

    }
}
