namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNullableInttoIntinOrderDetail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "OrderDurationMin", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "ProducedQuantity", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "TeigteileruhrDurationMin", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "PlannedKg", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "ProducedKg", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "BakeryTotalWaste", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "PackageTotalWaste", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "TotalDowntime", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "StillStandMin", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "StillStandPieces", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "TotalWasteKg", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "TotalWastePieces", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "TotalProduction", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "Sollmengen", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "LeerIndexMinute", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "LeerIndexPieces", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "LeerIndexPieces", c => c.Int());
            AlterColumn("dbo.OrderDetails", "LeerIndexMinute", c => c.Int());
            AlterColumn("dbo.OrderDetails", "Sollmengen", c => c.Int());
            AlterColumn("dbo.OrderDetails", "TotalProduction", c => c.Int());
            AlterColumn("dbo.OrderDetails", "TotalWastePieces", c => c.Int());
            AlterColumn("dbo.OrderDetails", "TotalWasteKg", c => c.Int());
            AlterColumn("dbo.OrderDetails", "StillStandPieces", c => c.Int());
            AlterColumn("dbo.OrderDetails", "StillStandMin", c => c.Int());
            AlterColumn("dbo.OrderDetails", "TotalDowntime", c => c.Int());
            AlterColumn("dbo.OrderDetails", "PackageTotalWaste", c => c.Int());
            AlterColumn("dbo.OrderDetails", "BakeryTotalWaste", c => c.Int());
            AlterColumn("dbo.OrderDetails", "ProducedKg", c => c.Single());
            AlterColumn("dbo.OrderDetails", "PlannedKg", c => c.Single());
            AlterColumn("dbo.OrderDetails", "TeigteileruhrDurationMin", c => c.Int());
            AlterColumn("dbo.OrderDetails", "ProducedQuantity", c => c.Int());
            AlterColumn("dbo.OrderDetails", "OrderDurationMin", c => c.Int());
        }
    }
}
