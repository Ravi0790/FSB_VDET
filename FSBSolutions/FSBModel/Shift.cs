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
        [Display(Name = "Schichtname", Description = "Shift Name")]
        public string ShiftName { get; set; }

        [Required]
        [Display(Name = "Schichtstartzeit", Description = "Shift Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}")]
        public DateTime ShiftStartTime { get; set; }

        [Required]
        [Display(Name = "Schichtendezeit", Description = "Shift End Time")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}")]
        public DateTime ShiftEndTime { get; set; }

        [Display(Name = "Buchungskreis", Description = "Plant Name")]
        public int PlantId { get; set; }

        public virtual Plant Plant { get; set; }

        public bool Status { get; set; }
    }
}
