namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingUserIdMachineIdFromMachineModuleCompPart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Components", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Modules", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Machines", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Components", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Machines", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Modules", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Parts", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Parts", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Reasons", "UserType_UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.Components", new[] { "UserTypeId" });
            DropIndex("dbo.Components", new[] { "LineId" });
            DropIndex("dbo.Modules", new[] { "UserTypeId" });
            DropIndex("dbo.Modules", new[] { "LineId" });
            DropIndex("dbo.Machines", new[] { "UserTypeId" });
            DropIndex("dbo.Machines", new[] { "LineId" });
            DropIndex("dbo.Parts", new[] { "UserTypeId" });
            DropIndex("dbo.Parts", new[] { "LineId" });
            DropIndex("dbo.Reasons", new[] { "UserType_UserTypeId" });
            DropColumn("dbo.Components", "UserTypeId");
            DropColumn("dbo.Components", "LineId");
            DropColumn("dbo.Modules", "UserTypeId");
            DropColumn("dbo.Modules", "LineId");
            DropColumn("dbo.Machines", "UserTypeId");
            DropColumn("dbo.Machines", "LineId");
            DropColumn("dbo.Parts", "UserTypeId");
            DropColumn("dbo.Parts", "LineId");
            DropColumn("dbo.Reasons", "UserType_UserTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reasons", "UserType_UserTypeId", c => c.Int());
            AddColumn("dbo.Parts", "LineId", c => c.Int(nullable: false));
            AddColumn("dbo.Parts", "UserTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Machines", "LineId", c => c.Int(nullable: false));
            AddColumn("dbo.Machines", "UserTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Modules", "LineId", c => c.Int(nullable: false));
            AddColumn("dbo.Modules", "UserTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Components", "LineId", c => c.Int(nullable: false));
            AddColumn("dbo.Components", "UserTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reasons", "UserType_UserTypeId");
            CreateIndex("dbo.Parts", "LineId");
            CreateIndex("dbo.Parts", "UserTypeId");
            CreateIndex("dbo.Machines", "LineId");
            CreateIndex("dbo.Machines", "UserTypeId");
            CreateIndex("dbo.Modules", "LineId");
            CreateIndex("dbo.Modules", "UserTypeId");
            CreateIndex("dbo.Components", "LineId");
            CreateIndex("dbo.Components", "UserTypeId");
            AddForeignKey("dbo.Reasons", "UserType_UserTypeId", "dbo.UserTypes", "UserTypeId");
            AddForeignKey("dbo.Parts", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Parts", "LineId", "dbo.Lines", "LineId", cascadeDelete: true);
            AddForeignKey("dbo.Modules", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Machines", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Components", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Machines", "LineId", "dbo.Lines", "LineId", cascadeDelete: true);
            AddForeignKey("dbo.Modules", "LineId", "dbo.Lines", "LineId", cascadeDelete: true);
            AddForeignKey("dbo.Components", "LineId", "dbo.Lines", "LineId", cascadeDelete: true);
        }
    }
}
