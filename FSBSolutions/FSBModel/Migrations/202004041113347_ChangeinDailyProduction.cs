namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeinDailyProduction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DailyProductions", "Shift_ShiftId", "dbo.Shifts");
            DropIndex("dbo.DailyProductions", new[] { "Shift_ShiftId" });
            AddColumn("dbo.DailyProductions", "StartTime", c => c.String(nullable: false));
            AddColumn("dbo.DailyProductions", "EndTime", c => c.String(nullable: false));
            DropColumn("dbo.DailyProductions", "Shift_ShiftId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DailyProductions", "Shift_ShiftId", c => c.Int());
            DropColumn("dbo.DailyProductions", "EndTime");
            DropColumn("dbo.DailyProductions", "StartTime");
            CreateIndex("dbo.DailyProductions", "Shift_ShiftId");
            AddForeignKey("dbo.DailyProductions", "Shift_ShiftId", "dbo.Shifts", "ShiftId");
        }
    }
}
