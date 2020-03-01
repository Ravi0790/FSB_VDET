namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCutperminutetoSpeedinProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Speed", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "CutPerMinute");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CutPerMinute", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Speed");
        }
    }
}
