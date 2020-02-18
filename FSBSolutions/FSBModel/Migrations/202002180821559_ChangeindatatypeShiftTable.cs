namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeindatatypeShiftTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shifts", "ShiftStartTime", c => c.String(nullable: false));
            AlterColumn("dbo.Shifts", "ShiftEndTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shifts", "ShiftEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Shifts", "ShiftStartTime", c => c.DateTime(nullable: false));
        }
    }
}
