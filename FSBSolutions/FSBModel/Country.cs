﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Country
    {
        public int CountryId { get; set; }

        [Required(ErrorMessage ="Please enter Country Name")]
        [StringLength(100)]
        [Display(Name = "Ländernamen",Description ="Country Name")]
        public string CountryName { get; set; }        

        public IList<Company> Companies { get; set; }

        public bool Status { get; set; }
    }
}
