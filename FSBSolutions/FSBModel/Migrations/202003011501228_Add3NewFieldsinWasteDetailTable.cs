namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add3NewFieldsinWasteDetailTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WasteDetails", "ProblemReason", c => c.String());
            AddColumn("dbo.WasteDetails", "ActionTaken", c => c.String());
            AddColumn("dbo.WasteDetails", "PreventiveAction", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WasteDetails", "PreventiveAction");
            DropColumn("dbo.WasteDetails", "ActionTaken");
            DropColumn("dbo.WasteDetails", "ProblemReason");
        }
    }
}
