namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEfficiencyinWasteDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WasteDetails", "Efficiency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WasteDetails", "Efficiency");
        }
    }
}
