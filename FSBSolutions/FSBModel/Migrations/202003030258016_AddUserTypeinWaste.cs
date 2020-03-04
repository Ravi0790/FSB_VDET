namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTypeinWaste : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WasteDetails", "UserTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.WasteDetails", "UserTypeId");
            AddForeignKey("dbo.WasteDetails", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WasteDetails", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.WasteDetails", new[] { "UserTypeId" });
            DropColumn("dbo.WasteDetails", "UserTypeId");
        }
    }
}
