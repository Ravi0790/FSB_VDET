namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "BakingTime", c => c.String());
            AddColumn("dbo.Products", "BunPerTray", c => c.String());
            AddColumn("dbo.Products", "BunPerDolly", c => c.String());
            DropColumn("dbo.Products", "BakintTime");
            DropColumn("dbo.Products", "Dollies");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Dollies", c => c.String());
            AddColumn("dbo.Products", "BakintTime", c => c.String());
            DropColumn("dbo.Products", "BunPerDolly");
            DropColumn("dbo.Products", "BunPerTray");
            DropColumn("dbo.Products", "BakingTime");
        }
    }
}
