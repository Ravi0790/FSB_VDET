namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVerlustartIdinReason : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reasons", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Reasons", "Verlustart_VerlustartId", "dbo.Verlustarts");
            DropIndex("dbo.Reasons", new[] { "UserTypeId" });
            DropIndex("dbo.Reasons", new[] { "Verlustart_VerlustartId" });
            RenameColumn(table: "dbo.Reasons", name: "UserTypeId", newName: "UserType_UserTypeId");
            RenameColumn(table: "dbo.Reasons", name: "Verlustart_VerlustartId", newName: "VerlustartId");
            AlterColumn("dbo.Reasons", "UserType_UserTypeId", c => c.Int());
            AlterColumn("dbo.Reasons", "VerlustartId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reasons", "VerlustartId");
            CreateIndex("dbo.Reasons", "UserType_UserTypeId");
            AddForeignKey("dbo.Reasons", "UserType_UserTypeId", "dbo.UserTypes", "UserTypeId");
            AddForeignKey("dbo.Reasons", "VerlustartId", "dbo.Verlustarts", "VerlustartId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reasons", "VerlustartId", "dbo.Verlustarts");
            DropForeignKey("dbo.Reasons", "UserType_UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.Reasons", new[] { "UserType_UserTypeId" });
            DropIndex("dbo.Reasons", new[] { "VerlustartId" });
            AlterColumn("dbo.Reasons", "VerlustartId", c => c.Int());
            AlterColumn("dbo.Reasons", "UserType_UserTypeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Reasons", name: "VerlustartId", newName: "Verlustart_VerlustartId");
            RenameColumn(table: "dbo.Reasons", name: "UserType_UserTypeId", newName: "UserTypeId");
            CreateIndex("dbo.Reasons", "Verlustart_VerlustartId");
            CreateIndex("dbo.Reasons", "UserTypeId");
            AddForeignKey("dbo.Reasons", "Verlustart_VerlustartId", "dbo.Verlustarts", "VerlustartId");
            AddForeignKey("dbo.Reasons", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: true);
        }
    }
}
