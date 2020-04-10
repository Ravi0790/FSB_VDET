namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDailyProductionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyProductions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CDate = c.DateTime(nullable: false),
                        Line = c.String(nullable: false, maxLength: 20),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        ProductDesc = c.String(nullable: false, maxLength: 500),
                        ProductCountry = c.String(nullable: false, maxLength: 50),
                        Umrusten = c.Int(nullable: false),
                        Reinigung = c.Int(nullable: false),
                        Technische = c.Int(nullable: false),
                        Produktion = c.Int(nullable: false),
                        Menge = c.Int(nullable: false),
                        Auschuss = c.Int(nullable: false),
                        Brötchen = c.Int(nullable: false),
                        Shift_ShiftId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shifts", t => t.Shift_ShiftId)
                .Index(t => t.Shift_ShiftId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyProductions", "Shift_ShiftId", "dbo.Shifts");
            DropIndex("dbo.DailyProductions", new[] { "Shift_ShiftId" });
            DropTable("dbo.DailyProductions");
        }
    }
}
