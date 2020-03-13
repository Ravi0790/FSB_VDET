namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTypeinReason : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reasons", "UserTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reasons", "UserTypeId");
            AddForeignKey("dbo.Reasons", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reasons", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.Reasons", new[] { "UserTypeId" });
            DropColumn("dbo.Reasons", "UserTypeId");
        }
    }
}
