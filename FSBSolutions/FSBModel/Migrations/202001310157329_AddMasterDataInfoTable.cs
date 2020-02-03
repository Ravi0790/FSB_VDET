namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMasterDataInfoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MasterDataInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        UserName = c.String(),
                        UserType = c.String(),
                        Plant = c.String(),
                        Shift = c.String(),
                        Line = c.String(),
                        ProductName = c.String(),
                        ProductDesc = c.String(),
                        ProductSize = c.String(),
                        ProductCountry = c.String(),
                        CutPerMinute = c.String(),
                        BakingTime = c.Single(nullable: false),
                        DoughWeight = c.Single(nullable: false),
                        BunWeight = c.Single(nullable: false),
                        BunsPerTray = c.Single(nullable: false),
                        BunPerDough = c.Single(nullable: false),
                        Pockets = c.Single(nullable: false),
                        Flour = c.Single(nullable: false),
                        Oil = c.Single(nullable: false),
                        Sugar = c.Single(nullable: false),
                        Salt = c.Single(nullable: false),
                        Yeast = c.Single(nullable: false),
                        ProductType = c.String(),
                        PackagingUnit = c.String(),
                        PackagingUnitColor = c.String(),
                        MasterPackUnit = c.String(),
                        TrayName = c.String(),
                        BunPerDolly = c.Single(nullable: false),
                        ShiftStartTime = c.DateTime(nullable: false),
                        ShiftStopTime = c.DateTime(nullable: false),
                        ShiftDuration = c.Int(nullable: false),
                        OrderStartTime = c.DateTime(nullable: false),
                        OrderStopTime = c.DateTime(nullable: false),
                        OrderDuration = c.Int(nullable: false),
                        PlannedQuantity = c.Int(nullable: false),
                        ProducedQuantity = c.Int(nullable: false),
                        WasteId = c.Int(nullable: false),
                        MachineStartTime = c.DateTime(nullable: false),
                        MachineStopTime = c.DateTime(nullable: false),
                        MachineDuration = c.Int(nullable: false),
                        CleaningStartTime = c.DateTime(nullable: false),
                        CleaningStopTime = c.DateTime(nullable: false),
                        CleaningDuration = c.Int(nullable: false),
                        RepairStartTime = c.DateTime(nullable: false),
                        RepairEndTime = c.DateTime(nullable: false),
                        RepairDuration = c.Int(nullable: false),
                        WasteKg = c.Int(nullable: false),
                        Efficiency = c.String(),
                        WasteType = c.String(),
                        WasteCategory = c.String(),
                        Location = c.String(),
                        Machine = c.String(),
                        Module = c.String(),
                        Component = c.String(),
                        Parts = c.String(),
                        Reason = c.String(),
                        Comments = c.String(),
                        WasteDate = c.DateTime(nullable: false),
                        EnteredDate = c.DateTime(nullable: false),
                        ProductionType = c.String(),
                        PermanentEmp = c.String(),
                        TemporaryEmp = c.String(),
                        ExternalEmp = c.String(),
                        ProductionStatus = c.String(),
                        PDay = c.String(),
                        PYear = c.String(),
                        PQuarter = c.String(),
                        PMonth = c.String(),
                        PWeek = c.String(),
                        WastePcs = c.Int(nullable: false),
                        TimeLossPcs = c.Int(nullable: false),
                        TTStart = c.DateTime(nullable: false),
                        TTEnd = c.DateTime(nullable: false),
                        TTDuration = c.Int(nullable: false),
                        PlannedKg = c.Single(nullable: false),
                        ProducedKg = c.Single(nullable: false),
                        LeerIndexMinutes = c.Int(nullable: false),
                        LeerIndexPieces = c.Int(nullable: false),
                        IsLogin = c.Boolean(nullable: false),
                        Tray = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MasterDataInfoes");
        }
    }
}
