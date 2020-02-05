using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class UserType
    {
        public int UserTypeId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Benutzername", Description = "UserType Name")]
        public string UserTypeName { get; set; }

        [Display(Name = "Buchungskreis", Description = "Plant Name")]
        public int PlantId { get; set; }

        public Plant Plant { get; set; }
        public IList<User> Users { get; set; }
        public IList<Location> Locations { get; set; }
        public IList<Product> Products { get; set; }
        public IList<Verlust> Verlusts { get; set; }
        public IList<Verlustart> Verlustarts { get; set; }
        public IList<Reason> Reasons { get; set; }
        public IList<WasteType> WasteTypes { get; set; }        
        public bool Status { get; set; }
    }
}
