namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingnewfieldsinwastedetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WasteDetails", "WasteType", c => c.String(maxLength: 200));
            AddColumn("dbo.WasteDetails", "Verlust", c => c.String(maxLength: 200));
            AddColumn("dbo.WasteDetails", "Verlustart", c => c.String(maxLength: 200));
            AddColumn("dbo.WasteDetails", "Location", c => c.String(maxLength: 200));
            AddColumn("dbo.WasteDetails", "Machine", c => c.String(maxLength: 200));
            AddColumn("dbo.WasteDetails", "Module", c => c.String(maxLength: 200));
            AddColumn("dbo.WasteDetails", "Component", c => c.String(maxLength: 200));
            AddColumn("dbo.WasteDetails", "Part", c => c.String(maxLength: 200));
            AddColumn("dbo.WasteDetails", "Reason", c => c.String(maxLength: 200));
            DropColumn("dbo.WasteDetails", "CleaningApproverId");
            DropColumn("dbo.WasteDetails", "RepairingApporverId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WasteDetails", "RepairingApporverId", c => c.Int(nullable: false));
            AddColumn("dbo.WasteDetails", "CleaningApproverId", c => c.Int(nullable: false));
            DropColumn("dbo.WasteDetails", "Reason");
            DropColumn("dbo.WasteDetails", "Part");
            DropColumn("dbo.WasteDetails", "Component");
            DropColumn("dbo.WasteDetails", "Module");
            DropColumn("dbo.WasteDetails", "Machine");
            DropColumn("dbo.WasteDetails", "Location");
            DropColumn("dbo.WasteDetails", "Verlustart");
            DropColumn("dbo.WasteDetails", "Verlust");
            DropColumn("dbo.WasteDetails", "WasteType");
        }
    }
}
