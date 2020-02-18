namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeinPlantId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserTypes", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.Lines", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.Shifts", "PlantId", "dbo.Plants");
            DropPrimaryKey("dbo.Plants");
            DropColumn("dbo.Plants", "Id");
            AddColumn("dbo.Plants", "PlantId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Plants", "PlantId");
            AddForeignKey("dbo.UserTypes", "PlantId", "dbo.Plants", "PlantId", cascadeDelete: true);
            AddForeignKey("dbo.Lines", "PlantId", "dbo.Plants", "PlantId", cascadeDelete: true);
            AddForeignKey("dbo.Shifts", "PlantId", "dbo.Plants", "PlantId", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plants", "PlantId");
            AddColumn("dbo.Plants", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Shifts", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.Lines", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.UserTypes", "PlantId", "dbo.Plants");
            DropPrimaryKey("dbo.Plants");
            
            AddPrimaryKey("dbo.Plants", "Id");
            AddForeignKey("dbo.Shifts", "PlantId", "dbo.Plants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lines", "PlantId", "dbo.Plants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserTypes", "PlantId", "dbo.Plants", "Id", cascadeDelete: true);
        }
    }
}
