using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class ContainerWaste
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Datum")]
      
        [Display(Name = "Datum")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Please Enter  Lieferschein Nr")]
        [Display(Name = "Lieferschein Nr")]
        public int LieferscheinNr { get; set; }

        [Required(ErrorMessage = "Please Enter Waste Detail")]
        [StringLength(20)]
        [Display(Name = "Waste Detail")]
        public string WasteDetail { get; set; }

        [Required(ErrorMessage = "Please Enter Waste")]
         [Display(Name = "Waste (Kg)")]
        public int Waste { get; set; }

        [StringLength(20)]
        public string PDay { get; set; }
        [StringLength(20)]
        public string PYear { get; set; }
        [StringLength(20)]
        public string PQuarter { get; set; }
        [StringLength(20)]
        public string PMonth { get; set; }
        [StringLength(20)]
        public string Week { get; set; }
        public DateTime CrtdDate { get; set; }
    }
}
