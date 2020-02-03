namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVerlustartReasonWastetypeWasteCatTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        ReasonId = c.Int(nullable: false, identity: true),
                        ReasonName = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReasonId)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.Verlustarts",
                c => new
                    {
                        VerlustartId = c.Int(nullable: false, identity: true),
                        VerlustartName = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VerlustartId)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.WasteCategories",
                c => new
                    {
                        WasteCategoryId = c.Int(nullable: false, identity: true),
                        WasteCategoryName = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WasteCategoryId)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.WasteTypes",
                c => new
                    {
                        WasteTypeId = c.Int(nullable: false, identity: true),
                        WasteTypeName = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WasteTypeId)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WasteTypes", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.WasteCategories", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Verlustarts", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Reasons", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.WasteTypes", new[] { "UserTypeId" });
            DropIndex("dbo.WasteCategories", new[] { "UserTypeId" });
            DropIndex("dbo.Verlustarts", new[] { "UserTypeId" });
            DropIndex("dbo.Reasons", new[] { "UserTypeId" });
            DropTable("dbo.WasteTypes");
            DropTable("dbo.WasteCategories");
            DropTable("dbo.Verlustarts");
            DropTable("dbo.Reasons");
        }
    }
}
