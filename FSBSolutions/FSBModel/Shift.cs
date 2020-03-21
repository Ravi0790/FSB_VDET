using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Shift
    {
        public int ShiftId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Shift Name", Description = "Shift Name")]
        public string ShiftName { get; set; }

        [Required]
        [Display(Name = "Start Time", Description = "Shift Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}")]
        public string ShiftStartTime { get; set; }

        [Required]
        [Display(Name = "End Time", Description = "Shift End Time")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}")]
        public string ShiftEndTime { get; set; }

        [Display(Name = "Plant Name", Description = "Plant Name")]
        public int PlantId { get; set; }

        public virtual Plant Plant { get; set; }

        public bool Status { get; set; }
    }
}
