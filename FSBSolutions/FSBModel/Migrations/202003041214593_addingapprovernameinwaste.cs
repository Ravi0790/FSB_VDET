namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingapprovernameinwaste : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WasteDetails", "CleanerApproverName", c => c.String(maxLength: 200));
            AddColumn("dbo.WasteDetails", "RepairApproverName", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WasteDetails", "RepairApproverName");
            DropColumn("dbo.WasteDetails", "CleanerApproverName");
        }
    }
}
