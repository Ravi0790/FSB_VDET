using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Buchungskreis", Description = "Company Code")]
        public string CompanyCode { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Name der Firma", Description = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Ländernamen", Description = "Country Name")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public IList<Plant> Plants { get; set; }

        public bool Status { get; set; }


    }
}
