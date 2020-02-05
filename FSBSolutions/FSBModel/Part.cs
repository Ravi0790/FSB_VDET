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

        public int ComponentId { get; set; }

        [Display(Name = "Komponentenname", Description = "Component Name")]
        public virtual Component Component { get; set; }

        public bool Status { get; set; }
    }
}
