namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeightUnitSpeedUnitinProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "WeightUnit", c => c.String(maxLength: 10));
            AddColumn("dbo.Products", "SpeedUnit", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "SpeedUnit");
            DropColumn("dbo.Products", "WeightUnit");
        }
    }
}
