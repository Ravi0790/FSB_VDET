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
        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [StringLength(50)]
        [Display(Name = "Description")]
        public string ProductDesc { get; set; }

        [StringLength(50)]
        [Display(Name = "Country")]
        public string ProductCountry { get; set; }

        [Required]        
        [Display(Name = "Pocket")]
        public int ProductPocket { get; set; }

        [Display(Name = "Size")]
        public float? ProductSize { get; set; }

        [Required]        
        [Display(Name = "Speed")]
        public int Speed { get; set; }

        [Display(Name = "Baking Time")]
        public int? BakingTime { get; set; }

        [Required]
        [Display(Name = "Dought Weight")]
        public float DoughWeight { get; set; }

        [Required]
        [Display(Name = "Bun Weight")]
        public float BunWeight { get; set; }

        [Display(Name = "Bun Per Dough")]
        public int? BunPerDough { get; set; }

        [Display(Name = "Bun Per Tray")]
        public int? BunPerTray { get; set; }

        [Required]
        [Display(Name = "Bun Per Dolly")]
        public int BunPerDolly { get; set; }//Dollies

        [Display(Name = "Flour")]
        public float? Flour { get; set; }


        [Display(Name = "Oil")]
        public float? Oil { get; set; }

        [Display(Name = "Sugar")]
        public float? Sugar { get; set; }

        [Display(Name = "Salt")]
        public float? Salt { get; set; }

        [Display(Name = "Yeast")]
        public float? Yeast { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Color")]
        public string ProductColor { get; set; }

        [StringLength(50)]
        [Display(Name = "Type")] //prod_misc1
        public string ProductType { get; set; }

        [Required]
        [StringLength(50)]//prod_misc2
        [Display(Name = "Packaging Unit")]
        public string PackagingUnit { get; set; }

        [StringLength(50)]//prod_misc3
        [Display(Name = "Packaging Unit Color")]
        public string PackagingUnitColor { get; set; }

        [StringLength(50)]//prod_misc4
        [Display(Name = "Master Pack Unit")]
        public string MasterPackUnit { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tray Name")]
        public string TrayName { get; set; }

        [StringLength(50)]
        [Display(Name = "Misc1")]
        public string Misc1 { get; set; }

        [StringLength(50)]
        [Display(Name = "Misc2")]
        public string Misc2 { get; set; }

        [StringLength(50)]
        [Display(Name = "Misc3")]
        public string Misc3 { get; set; }

        [StringLength(50)]
        [Display(Name = "Misc4")]
        public string Misc4 { get; set; }

        [StringLength(50)]
        [Display(Name = "Misc5")]
        public string Misc5 { get; set; }

        public bool Status { get; set; }

        
        [Display(Name = "Line")]
        public int LineId { get; set; }
        public virtual Line Line { get; set; }

        [Display(Name = "UserType")]
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        [Display(Name = "Weight Unit")]
        [StringLength(20)]
        public string WeightUnit { get; set; }

        [Display(Name = "Speed Unit")]
        [StringLength(20)]
        public string SpeedUnit { get; set; }

        //public int test1 { get; set; }

    }
}
