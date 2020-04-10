namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewfieldsindailyproduction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyProductions", "LineId", c => c.Int(nullable: false));
            AddColumn("dbo.DailyProductions", "ProductId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DailyProductions", "ProductId");
            DropColumn("dbo.DailyProductions", "LineId");
        }
    }
}
