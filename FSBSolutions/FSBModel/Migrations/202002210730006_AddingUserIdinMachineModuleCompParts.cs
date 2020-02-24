namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserIdinMachineModuleCompParts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Machines", "UserTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Machines", "LineId", c => c.Int(nullable: false));
            AddColumn("dbo.Modules", "UserTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Modules", "LineId", c => c.Int(nullable: false));
            AddColumn("dbo.Components", "UserTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Components", "LineId", c => c.Int(nullable: false));
            AddColumn("dbo.Parts", "UserTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Parts", "LineId", c => c.Int(nullable: false));
            CreateIndex("dbo.Components", "UserTypeId");
            CreateIndex("dbo.Components", "LineId");
            CreateIndex("dbo.Modules", "UserTypeId");
            CreateIndex("dbo.Modules", "LineId");
            CreateIndex("dbo.Machines", "UserTypeId");
            CreateIndex("dbo.Machines", "LineId");
            CreateIndex("dbo.Parts", "UserTypeId");
            CreateIndex("dbo.Parts", "LineId");
            AddForeignKey("dbo.Components", "LineId", "dbo.Lines", "LineId", cascadeDelete: false);
            AddForeignKey("dbo.Modules", "LineId", "dbo.Lines", "LineId", cascadeDelete: false);
            AddForeignKey("dbo.Machines", "LineId", "dbo.Lines", "LineId", cascadeDelete: false);
            AddForeignKey("dbo.Components", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: false);
            AddForeignKey("dbo.Machines", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: false);
            AddForeignKey("dbo.Modules", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: false);
            AddForeignKey("dbo.Parts", "LineId", "dbo.Lines", "LineId", cascadeDelete: false);
            AddForeignKey("dbo.Parts", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Parts", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Modules", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Machines", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Components", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Machines", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Modules", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Components", "LineId", "dbo.Lines");
            DropIndex("dbo.Parts", new[] { "LineId" });
            DropIndex("dbo.Parts", new[] { "UserTypeId" });
            DropIndex("dbo.Machines", new[] { "LineId" });
            DropIndex("dbo.Machines", new[] { "UserTypeId" });
            DropIndex("dbo.Modules", new[] { "LineId" });
            DropIndex("dbo.Modules", new[] { "UserTypeId" });
            DropIndex("dbo.Components", new[] { "LineId" });
            DropIndex("dbo.Components", new[] { "UserTypeId" });
            DropColumn("dbo.Parts", "LineId");
            DropColumn("dbo.Parts", "UserTypeId");
            DropColumn("dbo.Components", "LineId");
            DropColumn("dbo.Components", "UserTypeId");
            DropColumn("dbo.Modules", "LineId");
            DropColumn("dbo.Modules", "UserTypeId");
            DropColumn("dbo.Machines", "LineId");
            DropColumn("dbo.Machines", "UserTypeId");
        }
    }
}
