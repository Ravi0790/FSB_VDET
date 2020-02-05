namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppliyingAttributesinShiftandLine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lines", "LineName", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lines", "LineName", c => c.String());
        }
    }
}
