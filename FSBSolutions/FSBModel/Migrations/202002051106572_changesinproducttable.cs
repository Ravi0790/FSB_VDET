namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesinproducttable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "ProductDesc", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "ProductCountry", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "ProductPocket", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProductSize", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "CutPerMinute", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BakingTime", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "DoughWeight", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "BunWeight", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "BunPerDough", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BunPerTray", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BunPerDolly", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Flour", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "Oil", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "Sugar", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "Salt", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "Yeast", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "ProductColor", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "ProductType", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "PackagingUnit", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "PackagingUnitColor", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "MasterPackUnit", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "TrayName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Misc1", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Misc2", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Misc3", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Misc4", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Misc5", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Misc5", c => c.String());
            AlterColumn("dbo.Products", "Misc4", c => c.String());
            AlterColumn("dbo.Products", "Misc3", c => c.String());
            AlterColumn("dbo.Products", "Misc2", c => c.String());
            AlterColumn("dbo.Products", "Misc1", c => c.String());
            AlterColumn("dbo.Products", "TrayName", c => c.String());
            AlterColumn("dbo.Products", "MasterPackUnit", c => c.String());
            AlterColumn("dbo.Products", "PackagingUnitColor", c => c.String());
            AlterColumn("dbo.Products", "PackagingUnit", c => c.String());
            AlterColumn("dbo.Products", "ProductType", c => c.String());
            AlterColumn("dbo.Products", "ProductColor", c => c.String());
            AlterColumn("dbo.Products", "Yeast", c => c.String());
            AlterColumn("dbo.Products", "Salt", c => c.String());
            AlterColumn("dbo.Products", "Sugar", c => c.String());
            AlterColumn("dbo.Products", "Oil", c => c.String());
            AlterColumn("dbo.Products", "Flour", c => c.String());
            AlterColumn("dbo.Products", "BunPerDolly", c => c.String());
            AlterColumn("dbo.Products", "BunPerTray", c => c.String());
            AlterColumn("dbo.Products", "BunPerDough", c => c.String());
            AlterColumn("dbo.Products", "BunWeight", c => c.String());
            AlterColumn("dbo.Products", "DoughWeight", c => c.String());
            AlterColumn("dbo.Products", "BakingTime", c => c.String());
            AlterColumn("dbo.Products", "CutPerMinute", c => c.String());
            AlterColumn("dbo.Products", "ProductSize", c => c.String());
            AlterColumn("dbo.Products", "ProductPocket", c => c.String());
            AlterColumn("dbo.Products", "ProductCountry", c => c.String());
            AlterColumn("dbo.Products", "ProductDesc", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
        }
    }
}
