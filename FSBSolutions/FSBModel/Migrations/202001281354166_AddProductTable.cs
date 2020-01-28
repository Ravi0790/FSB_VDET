namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDesc = c.String(),
                        ProductCountry = c.String(),
                        ProductPocket = c.String(),
                        ProductSize = c.String(),
                        CutPerMinute = c.String(),
                        BakintTime = c.String(),
                        DoughWeight = c.String(),
                        BunWeight = c.String(),
                        BunPerDough = c.String(),
                        Dollies = c.String(),
                        Flour = c.String(),
                        Oil = c.String(),
                        Sugar = c.String(),
                        Salt = c.String(),
                        Yeast = c.String(),
                        ProductColor = c.String(),
                        ProductType = c.String(),
                        PackagingUnit = c.String(),
                        PackagingUnitColor = c.String(),
                        MasterPackUnit = c.String(),
                        TrayName = c.String(),
                        Misc1 = c.String(),
                        Misc2 = c.String(),
                        Misc3 = c.String(),
                        Misc4 = c.String(),
                        Misc5 = c.String(),
                        Status = c.Int(nullable: false),
                        LineId = c.Int(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Lines", t => t.LineId, cascadeDelete: false)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: false)
                .Index(t => t.LineId)
                .Index(t => t.UserTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Products", "LineId", "dbo.Lines");
            DropIndex("dbo.Products", new[] { "UserTypeId" });
            DropIndex("dbo.Products", new[] { "LineId" });
            DropTable("dbo.Products");
        }
    }
}
