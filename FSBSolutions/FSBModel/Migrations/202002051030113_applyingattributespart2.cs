namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyingattributespart2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "LocationName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Machines", "MachineName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Modules", "ModuleName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Components", "ComponentName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Parts", "PartName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.UserTypes", "UserTypeName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Reasons", "ReasonName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Verlustarts", "VerlustartName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "UserLoginId", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "UserPassword", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Verlusts", "VerlustName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.WasteTypes", "WasteTypeName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Shifts", "ShiftName", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shifts", "ShiftName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.WasteTypes", "WasteTypeName", c => c.String());
            AlterColumn("dbo.Verlusts", "VerlustName", c => c.String());
            AlterColumn("dbo.Users", "UserPassword", c => c.String());
            AlterColumn("dbo.Users", "UserLoginId", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Verlustarts", "VerlustartName", c => c.String());
            AlterColumn("dbo.Reasons", "ReasonName", c => c.String());
            AlterColumn("dbo.UserTypes", "UserTypeName", c => c.String());
            AlterColumn("dbo.Parts", "PartName", c => c.String());
            AlterColumn("dbo.Components", "ComponentName", c => c.String());
            AlterColumn("dbo.Modules", "ModuleName", c => c.String());
            AlterColumn("dbo.Machines", "MachineName", c => c.String());
            AlterColumn("dbo.Locations", "LocationName", c => c.String());
        }
    }
}
