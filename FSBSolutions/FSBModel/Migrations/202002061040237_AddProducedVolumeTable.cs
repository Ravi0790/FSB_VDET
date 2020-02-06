namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProducedVolumeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderProducedVolumes",
                c => new
                    {
                        ProducedVolumeId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        TimeSlot = c.String(),
                        Dollies = c.Int(nullable: false),
                        Korbe = c.Int(nullable: false),
                        Pieces = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProducedVolumeId)
                .ForeignKey("dbo.OrderDetails", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducedVolumes", "OrderId", "dbo.OrderDetails");
            DropIndex("dbo.OrderProducedVolumes", new[] { "OrderId" });
            DropTable("dbo.OrderProducedVolumes");
        }
    }
}
