﻿using System;
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
        [Display(Name = "Company Code", Description = "Company Code")]
        public string CompanyCode { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Company Name", Description = "Company Name")]
        public string CompanyName { get; set; }


        [Display(Name = "Country Name", Description = "Country Name")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public IList<Plant> Plants { get; set; }

        public bool Status { get; set; }


    }
}
