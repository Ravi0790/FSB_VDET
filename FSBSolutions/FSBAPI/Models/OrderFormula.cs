using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSBModel;
using System.Data.Entity;

namespace FSBAPI.Models
{
    public class OrderFormula
    {
        private FSBDBContext db = new FSBDBContext();
        public int PlannedQuantity { get; set; }
        public int ProducedQuantity { get; set; }
        public int Speed { get; set; }
        public int Pocket { get; set; }
        public int? BunPerTray { get; set; }
        public int BunPerDolly { get; set; }
        public float BunWeight { get; set; }
        public int PlannedKg { get; set; }
        public int ProducedKg { get; set; }
        public int BakeryTotalWaste { get; set; }
        public int PackageTotalWaste { get; set; }
        public int TotalDowntime { get; set; }
        public int StillStandMin { get; set; }
        public int StillStandPieces { get; set; }
        public int TotalWasteKg { get; set; }
        public int TotalWastePieces { get; set; }
        public int TotalProduction { get; set; }
        public int Sollmengen { get; set; }
        public int LeerIndexMinute { get; set; }
        public int LeerIndexPieces { get; set; }
        


        public OrderFormula CreateFormula(int orderid)
        {
            OrderDetail orderdetail = db.OrderDetails
                                        .Include(o=>o.Product)
                                        .SingleOrDefault(o => o.OrderId == orderid);

            var plannedquantity = orderdetail.PlannedQuantity;
            //var producedquantity = orderdetail.ProducedQuantity == null ? 0 : orderdetail.ProducedQuantity;
            var producedquantity = orderdetail.ProducedQuantity;
            var speed = orderdetail.Product.Speed;
            var pocket = orderdetail.Product.ProductPocket;
            var bunweight = orderdetail.Product.BunWeight;
            var bunpertray = orderdetail.Product.BunPerTray;
            var bunperdolly = orderdetail.Product.BunPerDolly;


            IList<WasteDetail> wastedetails = db.WasteDetails
                                              .Include(w=>w.UserType)
                                              .Where(w => w.OrderId == orderid).ToList();


            //bakerytotalwaste=sum(wastekg) where usertype='Bakery' and efficiency=1
            var bakerytotalwaste = wastedetails.Where(w => w.UserType.UserTypeName.ToLower() == "bakery" && w.Efficiency == 1).Sum(w => w.WasteKg);

            //packagingtotalwaste=sum(wastekg) where usertype='Packaging' and efficiency=1
            var packagingtotalwaste = wastedetails.Where(w => w.UserType.UserTypeName.ToLower() == "packaging" && w.Efficiency == 1).Sum(w => w.WasteKg);

            //TotalDownTime=sum(machineduration) where usertype='Bakery' and efficiency=0
            var totaldowntime = wastedetails.Where(w => w.UserType.UserTypeName.ToLower() == "bakery" && w.Efficiency == 1).Sum(w => w.MachinDurationMin);


            //StillStandMinute=sum(machineduration) where usertype='Bakery' and wastetype='Zeit'
            var stillstandminute = wastedetails.Where(w => w.UserType.UserTypeName.ToLower() == "bakery" && w.WasteType == "Zeit").Sum(w => w.MachinDurationMin);

            //StillStandPieces=sum(TimelossPieces) where usertype='Bakery' and wastetype='Zeit'
            var stillstandpieces= wastedetails.Where(w => w.UserType.UserTypeName.ToLower() == "bakery" && w.WasteType == "Zeit").Sum(w => w.TimelossPieces);

            //TotalWasteKg
            var totalwastekg = wastedetails.Sum(w => w.WasteKg);

            //TotalWastePieces
            var totalwastepiece = wastedetails.Sum(w => w.WastePieces);

            //Sollmengen=PlannedQuantity-Stillstandpcs
            var sollmengen = plannedquantity - stillstandpieces;

            //TotalProduction=(TotalWastePieces + ProducedQuantity)   //ProducedQuantity comes from packaging
            var totalproduction = totalwastepiece + producedquantity;

            //LeerIndexPiece=(TotalProduction - Sollmengen)
            var leerindexpiece = totalproduction - sollmengen;

            //LeerIndexMinute=leerindexpcs/(speed*pocket)
            var leerindexminute = leerindexpiece / (speed * pocket);


            //ProducedKg
            var producedkg = Math.Round((producedquantity * bunweight) / 1000);

            //PlanneKg
            var plannedkg = Math.Round((plannedquantity * bunweight) / 1000);


            OrderFormula objformula = new OrderFormula();

            objformula.PlannedQuantity = plannedquantity;
            objformula.ProducedQuantity = producedquantity;
            objformula.Speed = speed;
            objformula.Pocket = pocket;
            objformula.BunWeight = bunweight;
            objformula.BunPerTray = bunpertray;
            objformula.BunPerDolly = bunperdolly;
            objformula.BakeryTotalWaste = bakerytotalwaste;
            objformula.PackageTotalWaste = packagingtotalwaste;
            objformula.TotalDowntime = totaldowntime;
            objformula.TotalWasteKg = totalwastekg;
            objformula.TotalWastePieces = totalwastepiece;
            objformula.TotalProduction = totalproduction;
            objformula.Sollmengen = sollmengen;
            objformula.StillStandMin = stillstandminute;
            objformula.StillStandPieces = stillstandpieces;
            objformula.LeerIndexMinute = leerindexminute;
            objformula.LeerIndexPieces = leerindexpiece;
            objformula.PlannedKg = Convert.ToInt32(plannedkg);
            objformula.ProducedKg = Convert.ToInt32(producedkg);
           


            return objformula;




        }
    }
}