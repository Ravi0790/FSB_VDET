namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTypeAndUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeId = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(),
                        PlantId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserTypeId)
                .ForeignKey("dbo.Plants", t => t.PlantId, cascadeDelete: true)
                .Index(t => t.PlantId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserLoginId = c.String(),
                        UserPassword = c.String(),
                        UserTypeId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.UserTypes", "PlantId", "dbo.Plants");
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.UserTypes", new[] { "PlantId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserTypes");
        }
    }
}
