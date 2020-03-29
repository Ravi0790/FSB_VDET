namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDurationinVolumeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderProducedVolumes", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderProducedVolumes", "Duration");
        }
    }
}
