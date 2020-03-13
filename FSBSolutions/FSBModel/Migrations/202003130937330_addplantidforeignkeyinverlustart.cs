namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addplantidforeignkeyinverlustart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Verlustarts", "PlantId", c => c.Int(nullable: true));
            CreateIndex("dbo.Verlustarts", "PlantId");
            AddForeignKey("dbo.Verlustarts", "PlantId", "dbo.Plants", "PlantId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Verlustarts", "PlantId", "dbo.Plants");
            DropIndex("dbo.Verlustarts", new[] { "PlantId" });
            DropColumn("dbo.Verlustarts", "PlantId");
        }
    }
}
