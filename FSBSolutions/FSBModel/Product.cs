using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        //[Display(Name = "Produktname")]
        public string ProductName { get; set; }

        [StringLength(50)]
        //[Display(Name = "Produktbeschreibung")]
        public string ProductDesc { get; set; }

        [StringLength(50)]
        //[Display(Name = "Produktland")]
        public string ProductCountry { get; set; }

        [Required]        
        //[Display(Name = "Produkttasche")]
        public int ProductPocket { get; set; }

        //[Display(Name = "Produktgröße")]
        public float? ProductSize { get; set; }

        [Required]        
        //[Display(Name = "Schnitt pro Minute")]
        public int Speed { get; set; }

        //[Display(Name = "Backzeit")]
        public int? BakingTime { get; set; }

        [Required]
        //[Display(Name = "Teiggewicht")]
        public float DoughWeight { get; set; }

        [Required]
        //[Display(Name = "Brötchengewicht")]
        public float BunWeight { get; set; }

        //[Display(Name = "Brötchen pro Teig")]
        public int? BunPerDough { get; set; }

        //[Display(Name = "Brötchen pro Tablett")]
        public int? BunPerTray { get; set; }

        [Required]
        //[Display(Name = "Brötchen pro Dolly")]
        public int BunPerDolly { get; set; }//Dollies

        //[Display(Name = "Mehl")]
        public float? Flour { get; set; }


        //[Display(Name = "Öl")]
        public float? Oil { get; set; }

        //[Display(Name = "Zucker")]
        public float? Sugar { get; set; }

        //[Display(Name = "Salz-")]
        public float? Salt { get; set; }

        //[Display(Name = "Hefe")]
        public float? Yeast { get; set; }

        [Required]
        [StringLength(50)]
        //[Display(Name = "Produktfarbe")]
        public string ProductColor { get; set; }

        [StringLength(50)]
        //[Display(Name = "Produktart")]
        public string ProductType { get; set; }

        [Required]
        [StringLength(50)]
        //[Display(Name = "Packungseinheit")]
        public string PackagingUnit { get; set; }

        [StringLength(50)]
        //[Display(Name = "Farbe der Verpackungseinheit")]
        public string PackagingUnitColor { get; set; }

        [StringLength(50)]
        //[Display(Name = "Master-Pack-Einheit")]
        public string MasterPackUnit { get; set; }

        [Required]
        [StringLength(50)]
        //[Display(Name = "Fachname")]
        public string TrayName { get; set; }

        [StringLength(50)]
        //[Display(Name = "Sonstiges1")]
        public string Misc1 { get; set; }

        [StringLength(50)]
        //[Display(Name = "Sonstiges2")]
        public string Misc2 { get; set; }

        [StringLength(50)]
        //[Display(Name = "Sonstiges3")]
        public string Misc3 { get; set; }

        [StringLength(50)]
        //[Display(Name = "Sonstiges4")]
        public string Misc4 { get; set; }

        [StringLength(50)]
        //[Display(Name = "Sonstiges5")]
        public string Misc5 { get; set; }

        public bool Status { get; set; }

        
        //[Display(Name = "Zeilenname")]
        public int LineId { get; set; }
        public virtual Line Line { get; set; }

        //[Display(Name = "Benutzername")]
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        [StringLength(10)]
        public string WeightUnit { get; set; }

        [StringLength(10)]
        public string SpeedUnit { get; set; }

    }
}
