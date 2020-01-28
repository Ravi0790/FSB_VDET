namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        Status = c.Boolean(nullable: false),
                        LineId = c.Int(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Lines", t => t.LineId, cascadeDelete: false)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: false)
                .Index(t => t.LineId)
                .Index(t => t.UserTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Locations", "LineId", "dbo.Lines");
            DropIndex("dbo.Locations", new[] { "UserTypeId" });
            DropIndex("dbo.Locations", new[] { "LineId" });
            DropTable("dbo.Locations");
        }
    }
}
