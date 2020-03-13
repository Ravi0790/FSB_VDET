namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeinWeightSpeedUnitLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "WeightUnit", c => c.String(maxLength: 20));
            AlterColumn("dbo.Products", "SpeedUnit", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "SpeedUnit", c => c.String(maxLength: 10));
            AlterColumn("dbo.Products", "WeightUnit", c => c.String(maxLength: 10));
        }
    }
}
