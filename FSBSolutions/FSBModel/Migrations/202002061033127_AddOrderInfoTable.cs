namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderInfoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderInfoes",
                c => new
                    {
                        OrderInfoId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        OrderStatus = c.Int(nullable: false,defaultValue:0),
                        LoggedinTime = c.DateTime(nullable: false),
                        UpdatedLoggedinTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderInfoId)
                .ForeignKey("dbo.OrderDetails", t => t.OrderId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: false)
                .Index(t => t.OrderId)
                .Index(t => t.UserTypeId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderInfoes", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.OrderInfoes", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderInfoes", "OrderId", "dbo.OrderDetails");
            DropIndex("dbo.OrderInfoes", new[] { "UserId" });
            DropIndex("dbo.OrderInfoes", new[] { "UserTypeId" });
            DropIndex("dbo.OrderInfoes", new[] { "OrderId" });
            DropTable("dbo.OrderInfoes");
        }
    }
}
