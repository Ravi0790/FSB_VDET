namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLineTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lines",
                c => new
                    {
                        LineId = c.Int(nullable: false, identity: true),
                        LineName = c.String(),
                        PlantId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LineId)
                .ForeignKey("dbo.Plants", t => t.PlantId, cascadeDelete: true)
                .Index(t => t.PlantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lines", "PlantId", "dbo.Plants");
            DropIndex("dbo.Lines", new[] { "PlantId" });
            DropTable("dbo.Lines");
        }
    }
}
