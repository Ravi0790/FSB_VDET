namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DailyProdtableField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyProductions", "PDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DailyProductions", "DpDay", c => c.String());
            AddColumn("dbo.DailyProductions", "DpYear", c => c.String());
            AddColumn("dbo.DailyProductions", "DpQuarter", c => c.String());
            AddColumn("dbo.DailyProductions", "DpMonth", c => c.String());
            AddColumn("dbo.DailyProductions", "DpWeek", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DailyProductions", "DpWeek");
            DropColumn("dbo.DailyProductions", "DpMonth");
            DropColumn("dbo.DailyProductions", "DpQuarter");
            DropColumn("dbo.DailyProductions", "DpYear");
            DropColumn("dbo.DailyProductions", "DpDay");
            DropColumn("dbo.DailyProductions", "PDate");
        }
    }
}
