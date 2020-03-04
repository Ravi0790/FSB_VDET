namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserfromOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "UserId", "dbo.Users");
            DropIndex("dbo.OrderDetails", new[] { "UserId" });
            DropColumn("dbo.OrderDetails", "UserId");
            DropColumn("dbo.OrderInfoes", "UpdatedLoggedinTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderInfoes", "UpdatedLoggedinTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderDetails", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "UserId");
            AddForeignKey("dbo.OrderDetails", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
