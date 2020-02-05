using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class WasteType
    {
        public int WasteTypeId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Name der Abfallart", Description = "Waste Type Name")]
        public string WasteTypeName { get; set; }

        [Display(Name = "Benutzername", Description = "UserType Name")]
        public int UserTypeId { get; set; }

        public UserType UserType { get; set; }

        public bool Status { get; set; }
    }
}
