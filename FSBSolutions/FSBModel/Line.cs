using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Line
    {
        public int LineId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Line Name", Description = "Line Name")]
        public string LineName { get; set; }

        [Display(Name = "Plant Name", Description = "Plant Name")]
        public int PlantId { get; set; }
        public virtual Plant Plant { get; set; }
        public IList<Location> Locations { get; set; }
        //public IList<Machine> Machines { get; set; }
        //public IList<Module> Modules { get; set; }
        //public IList<Component> Components { get; set; }
        //public IList<Part> Parts { get; set; }
        public IList<Product> Products { get; set; }
        public bool Status { get; set; }
    }
}
