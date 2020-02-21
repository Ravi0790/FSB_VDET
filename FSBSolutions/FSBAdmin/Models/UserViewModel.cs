using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FSBModel;

namespace FSBAdmin.Models
{
    public class UserViewModel
    {
        public User User { get; set; }

        [Required]
        [Display(Name ="Country")]
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Plant")]
        public int PlantId { get; set; }
    }
}