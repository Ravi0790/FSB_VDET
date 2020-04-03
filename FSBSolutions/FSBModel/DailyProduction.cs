using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
  public class DailyProduction
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Datum", Description = "Datum")]
        public DateTime CDate { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Linie", Description = "Linie")]
        public string Line { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Product", Description = "Product")]
        public string ProductName { get; set; }
        [Required]
        [StringLength(500)]
        [Display(Name = "Product Description", Description = "Product Description")]
        public string ProductDesc { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Kunde", Description = "Kunde")]
        public string ProductCountry { get; set; }

        [Required]
       [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}")]
        [Display(Name = "Start Time", Description = "Start Time")]
        public  DateTime StartTime { get; set; }

        [Required]
       [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}")]
        [Display(Name = "End Time", Description = "End Time")]
        public  DateTime EndTime { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Umrusten(mins)", Description = "Umrusten(mins)")]
        public int Umrusten { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Reinigung(mins)", Description = "Reinigung(mins)")]
        public int Reinigung { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Technische(mins)", Description = "Technische(mins)")]
        public int Technische { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Produktion(mins)", Description = "Produktion(mins)")]
        public int Produktion { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Menge(pcs)", Description = "Menge(pcs)")]
        public int Menge { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Auschuss - Teig(kg)", Description = "Auschuss - Teig(kg)")]
        public int Auschuss{ get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Auschuss - Brötchen(kg)", Description = "Auschuss - Brötchen(kg)")]
        public int Brötchen { get; set; }
    }
}
