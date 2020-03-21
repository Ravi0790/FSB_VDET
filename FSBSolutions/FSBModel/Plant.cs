using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Plant
    {
        public int PlantId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Plant Code", Description = "Plant Code")]
        public string PlantCode { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Plant Name", Description = "Plant Name")]
        public string PlantName { get; set; }

        [Display(Name = "Company Name", Description = "Company Name")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public IList<Shift> Shifts { get; set; }

        public IList<Line> Lines { get; set; }

        public IList<UserType> UserTypes { get; set; }

        public IList<Verlustart> Verlustarts { get; set; }

        public bool Status { get; set; }
    }
}
