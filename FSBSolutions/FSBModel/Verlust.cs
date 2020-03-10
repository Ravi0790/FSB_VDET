using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    /***************This is Loss Type************/
    public class Verlust
    {
        public int VerlustId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Verlust Name", Description = "Verlust Name")]
        public string VerlustName { get; set; }

        [Display(Name = "Benutzername", Description = "UserType Name")]
        public int UserTypeId { get; set; }

        public UserType UserType { get; set; }

        public bool Status { get; set; }
    }
}
