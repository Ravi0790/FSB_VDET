using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FSBModel;

namespace FSBAdmin.Models
{
    public class ComponentViewModel
    {
        public Component Component { get; set; }

        [Required]
        [Display(Name ="Country")]
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Plant")]
        public int PlantId { get; set; }

        [Required]
        [Display(Name = "User Type")]
        public int UserTypeId { get; set; }

        [Required]
        [Display(Name = "Line")]
        public int LineId { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Machine")]
        public int MachineId { get; set; }



    }
}