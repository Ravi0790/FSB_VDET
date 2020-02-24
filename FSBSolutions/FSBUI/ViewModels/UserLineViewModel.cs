using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FSBModel;

namespace FSBUI.ViewModels
{
    public class UserLineViewModel
    {
        public User User { get; set; }

        [Required(ErrorMessage ="Please select Linie")]
        public int LineId { get; set; }
    }
}