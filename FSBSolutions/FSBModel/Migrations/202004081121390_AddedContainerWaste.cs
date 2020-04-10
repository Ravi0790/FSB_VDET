namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContainerWaste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContainerWastes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        LieferscheinNr = c.Int(nullable: false),
                        WasteDetail = c.String(nullable: false, maxLength: 20),
                        Waste = c.Int(nullable: false),
                        PDay = c.String(maxLength: 20),
                        PYear = c.String(maxLength: 20),
                        PQuarter = c.String(maxLength: 20),
                        PMonth = c.String(maxLength: 20),
                        Week = c.String(maxLength: 20),
                        CrtdDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContainerWastes");
        }
    }
}
