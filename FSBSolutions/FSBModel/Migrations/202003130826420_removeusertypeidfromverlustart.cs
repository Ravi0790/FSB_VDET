namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeusertypeidfromverlustart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Verlustarts", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.Verlustarts", new[] { "UserTypeId" });
            DropColumn("dbo.Verlustarts", "UserTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Verlustarts", "UserTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Verlustarts", "UserTypeId");
            AddForeignKey("dbo.Verlustarts", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: true);
        }
    }
}
