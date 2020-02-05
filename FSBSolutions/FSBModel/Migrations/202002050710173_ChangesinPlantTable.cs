namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesinPlantTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plants", "PlantCode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Companies", "CompanyCode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Companies", "CompanyName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Plants", "PlantName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Shifts", "ShiftName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shifts", "ShiftName", c => c.String());
            AlterColumn("dbo.Plants", "PlantName", c => c.String());
            AlterColumn("dbo.Companies", "CompanyName", c => c.String());
            AlterColumn("dbo.Companies", "CompanyCode", c => c.String());
            DropColumn("dbo.Plants", "PlantCode");
        }
    }
}
