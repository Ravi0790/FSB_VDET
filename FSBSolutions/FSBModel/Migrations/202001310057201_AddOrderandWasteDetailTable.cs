namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderandWasteDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        SAPReferenceNumber = c.String(),
                        UserTypeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ShiftId = c.Int(nullable: false),
                        LineId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OrderStartTime = c.DateTime(nullable: false),
                        OrderEndTime = c.DateTime(nullable: false),
                        OrderDurationMin = c.Int(nullable: false),
                        PlannedQuantity = c.Int(nullable: false),
                        ProducedQuantity = c.Int(nullable: false),
                        PremanentEmp = c.Int(nullable: false),
                        TemporaryEmp = c.Int(nullable: false),
                        ExternalEmp = c.Int(nullable: false),
                        TeigteileruhrStartTime = c.DateTime(nullable: false),
                        TeigteileruhrEndTime = c.DateTime(nullable: false),
                        TeigteileruhrDurationMin = c.Int(nullable: false),
                        PlannedKg = c.Single(nullable: false),
                        ProducedKg = c.Single(nullable: false),
                        BakeryTotalWaste = c.Int(nullable: false),
                        PackageTotalWaste = c.Int(nullable: false),
                        TotalDowntime = c.Int(nullable: false),
                        StillStandMin = c.Int(nullable: false),
                        StillStandPieces = c.Int(nullable: false),
                        TotalWasteKg = c.Int(nullable: false),
                        TotalWastePieces = c.Int(nullable: false),
                        TotalProduction = c.Int(nullable: false),
                        Sollmengen = c.Int(nullable: false),
                        LeerIndexMinute = c.Int(nullable: false),
                        LeerIndexPieces = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.WasteDetails",
                c => new
                    {
                        WasteId = c.Int(nullable: false, identity: true),
                        MachineStartTime = c.DateTime(nullable: false),
                        MachineEndTime = c.DateTime(nullable: false),
                        MachinDurationMin = c.Int(nullable: false),
                        CleaningStartTime = c.DateTime(nullable: false),
                        CleaningEndTime = c.DateTime(nullable: false),
                        CleaningDurationMin = c.Int(nullable: false),
                        RepairStartTime = c.DateTime(nullable: false),
                        RepairEndTime = c.DateTime(nullable: false),
                        RepairDuration = c.Int(nullable: false),
                        WasteTypeId = c.Int(nullable: false),
                        Produktionsstatus = c.Boolean(nullable: false),
                        VerlustId = c.Int(nullable: false),
                        VerlustartId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        MachineId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        ReasonId = c.Int(nullable: false),
                        comments = c.String(),
                        WasteKg = c.Int(nullable: false),
                        WastePieces = c.Int(nullable: false),
                        TimelossPieces = c.Int(nullable: false),
                        CleaningApproverId = c.Int(nullable: false),
                        RepairingApporverId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WasteId)
                .ForeignKey("dbo.OrderDetails", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WasteDetails", "OrderId", "dbo.OrderDetails");
            DropIndex("dbo.WasteDetails", new[] { "OrderId" });
            DropTable("dbo.WasteDetails");
            DropTable("dbo.OrderDetails");
        }
    }
}
