namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGeplateMengeEfficiencyinVolumTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderProducedVolumes", "GeplanteMenge", c => c.Int(nullable: false));
            AddColumn("dbo.OrderProducedVolumes", "Efficiency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderProducedVolumes", "Efficiency");
            DropColumn("dbo.OrderProducedVolumes", "GeplanteMenge");
        }
    }
}
