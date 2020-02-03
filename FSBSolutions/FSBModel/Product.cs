using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string ProductCountry { get; set; }
        public string ProductPocket { get; set; }
        public string ProductSize { get; set; }
        public string CutPerMinute { get; set; }
        public string BakingTime { get; set; }
        public string DoughWeight { get; set; }
        public string BunWeight { get; set; }
        public string BunPerDough { get; set; }
        public string BunPerTray { get; set; }
        public string BunPerDolly { get; set; }//Dollies
        public string Flour { get; set; }
        public string Oil { get; set; }
        public string Sugar { get; set; }
        public string Salt { get; set; }
        public string Yeast { get; set; }
        public string ProductColor { get; set; }
        public string ProductType { get; set; }
        public string PackagingUnit { get; set; }
        public string PackagingUnitColor { get; set; }
        public string MasterPackUnit { get; set; }
        public string TrayName { get; set; }
        public string Misc1 { get; set; }
        public string Misc2 { get; set; }
        public string Misc3 { get; set; }
        public string Misc4 { get; set; }
        public string Misc5 { get; set; }
        public int Status { get; set; }
        public int LineId { get; set; }
        public virtual Line Line { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

    }
}
