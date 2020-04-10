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

       // [Required(ErrorMessage ="Please enter the date")]
        
       // [Display(Name = "Datum", Description = "Datum")]
        public DateTime CDate { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie Line ein")]
        [StringLength(20)]
        [Display(Name = "Linie", Description = "Linie")]
        public string Line { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie den Produktnamen ein")]
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

        [Required (ErrorMessage = "Bitte Startzeit eingeben")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}")]
        [Display(Name = "Start Time", Description = "Start Time")]
        public string StartTime { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie die Endzeit ein")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}")]
        [Display(Name = "End Time", Description = "End Time")]
        public string EndTime { get; set; }
               

        [Required (ErrorMessage = "Please enter umrusten")]        
        [Display(Name = "Umrusten(mins)", Description = "Umrusten(mins)")]
        public int Umrusten { get; set; }

        [Required(ErrorMessage = "Please enter reinigung")]        
        [Display(Name = "Reinigung(mins)", Description = "Reinigung(mins)")]
        public int Reinigung { get; set; }

        [Required (ErrorMessage = "Please enter technische")]        
        [Display(Name = "Technische(mins)", Description = "Technische(mins)")]
        public int Technische { get; set; }

        [Required (ErrorMessage = "Bitte geben Sie die Produktion ein")]        
        [Display(Name = "Produktion(mins)", Description = "Produktion(mins)")]
        public int Produktion { get; set; }

        [Required (ErrorMessage = "Please enter menge")]        
        [Display(Name = "Menge(pcs)", Description = "Menge(pcs)")]
        public int Menge { get; set; }

        [Required]       
        [Display(Name = "Auschuss - Teig(kg)", Description = "Auschuss - Teig(kg)")]
        public int Auschuss{ get; set; }

        [Required (ErrorMessage = "Bitte geben Sie Auschuss - Brötchen ein")]       
        [Display(Name = "Auschuss - Brötchen(kg)", Description = "Auschuss - Brötchen(kg)")]
        public int Brötchen { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie das Datum ein")]
        [Display(Name = "Datum", Description = "Datum")]
        //[DataType(DataType.Date)]
        public DateTime PDate { get; set; }

        public string DpDay { get; set; }
        public string DpYear { get; set; }
        public string DpQuarter { get; set; }
        public string DpMonth { get; set; }
        public string DpWeek { get; set; }
        public int LineId { get; set; }
        public int ProductId { get; set; }
    }
}
