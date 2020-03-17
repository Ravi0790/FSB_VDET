namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRowIdinVolume : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderProducedVolumes", "DisplayRowId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderProducedVolumes", "DisplayRowId");
        }
    }
}
