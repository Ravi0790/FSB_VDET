namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makingsomecolumns_floatint_nullable_inproducttable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductSize", c => c.Single());
            AlterColumn("dbo.Products", "BakingTime", c => c.Int());
            AlterColumn("dbo.Products", "BunPerDough", c => c.Int());
            AlterColumn("dbo.Products", "BunPerTray", c => c.Int());
            AlterColumn("dbo.Products", "Flour", c => c.Single());
            AlterColumn("dbo.Products", "Oil", c => c.Single());
            AlterColumn("dbo.Products", "Sugar", c => c.Single());
            AlterColumn("dbo.Products", "Salt", c => c.Single());
            AlterColumn("dbo.Products", "Yeast", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Yeast", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "Salt", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "Sugar", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "Oil", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "Flour", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "BunPerTray", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BunPerDough", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BakingTime", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProductSize", c => c.Single(nullable: false));
        }
    }
}
