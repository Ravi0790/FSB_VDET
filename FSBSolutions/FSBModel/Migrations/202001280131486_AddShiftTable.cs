namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShiftTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftId = c.Int(nullable: false, identity: true),
                        ShiftName = c.String(),
                        ShiftStartTime = c.DateTime(nullable: false),
                        ShiftEndTime = c.DateTime(nullable: false),
                        PlantId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftId)
                .ForeignKey("dbo.Plants", t => t.PlantId, cascadeDelete: true)
                .Index(t => t.PlantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "PlantId", "dbo.Plants");
            DropIndex("dbo.Shifts", new[] { "PlantId" });
            DropTable("dbo.Shifts");
        }
    }
}
