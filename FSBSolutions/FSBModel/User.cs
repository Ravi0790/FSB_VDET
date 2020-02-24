using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Nutzername", Description = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bitte den  Benutzernamen eingeben")]
        [StringLength(100)]
        [Display(Name = "Benutzename", Description = "User Id")]
        public string UserLoginId { get; set; }

        [Required(ErrorMessage = "Bitte das Passwort eingeben")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort", Description = "Password")]
        public string UserPassword { get; set; }

        [Display(Name = "Benutzername", Description = "UserType Name")]
        public int UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }

        public bool Status { get; set; }
    }
}
