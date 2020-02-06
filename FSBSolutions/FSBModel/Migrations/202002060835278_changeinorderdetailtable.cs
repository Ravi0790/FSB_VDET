namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeinorderdetailtable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OrderDetails", "UserTypeId");
            CreateIndex("dbo.OrderDetails", "UserId");
            CreateIndex("dbo.OrderDetails", "ShiftId");
            CreateIndex("dbo.OrderDetails", "LineId");
            CreateIndex("dbo.OrderDetails", "ProductId");
            AddForeignKey("dbo.OrderDetails", "LineId", "dbo.Lines", "LineId", cascadeDelete: false);
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "ProductId", cascadeDelete: false);
            AddForeignKey("dbo.OrderDetails", "ShiftId", "dbo.Shifts", "ShiftId", cascadeDelete: false);
            AddForeignKey("dbo.OrderDetails", "UserId", "dbo.Users", "UserId", cascadeDelete: false);
            AddForeignKey("dbo.OrderDetails", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.OrderDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "ShiftId", "dbo.Shifts");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "LineId", "dbo.Lines");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "LineId" });
            DropIndex("dbo.OrderDetails", new[] { "ShiftId" });
            DropIndex("dbo.OrderDetails", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "UserTypeId" });
        }
    }
}
