namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makingdatetimenullableinwastedetail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WasteDetails", "MachineStartTime", c => c.DateTime());
            AlterColumn("dbo.WasteDetails", "MachineEndTime", c => c.DateTime());
            AlterColumn("dbo.WasteDetails", "CleaningStartTime", c => c.DateTime());
            AlterColumn("dbo.WasteDetails", "CleaningEndTime", c => c.DateTime());
            AlterColumn("dbo.WasteDetails", "RepairStartTime", c => c.DateTime());
            AlterColumn("dbo.WasteDetails", "RepairEndTime", c => c.DateTime());
            AlterColumn("dbo.WasteDetails", "Produktionsstatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WasteDetails", "Produktionsstatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.WasteDetails", "RepairEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WasteDetails", "RepairStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WasteDetails", "CleaningEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WasteDetails", "CleaningStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WasteDetails", "MachineEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WasteDetails", "MachineStartTime", c => c.DateTime(nullable: false));
        }
    }
}
