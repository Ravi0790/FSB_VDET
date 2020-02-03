namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeinVerlustartRelationsDropWasteCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WasteCategories", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.WasteCategories", new[] { "UserTypeId" });
            AddColumn("dbo.Reasons", "Verlustart_VerlustartId", c => c.Int());
            CreateIndex("dbo.Reasons", "Verlustart_VerlustartId");
            AddForeignKey("dbo.Reasons", "Verlustart_VerlustartId", "dbo.Verlustarts", "VerlustartId");
            DropTable("dbo.WasteCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WasteCategories",
                c => new
                    {
                        WasteCategoryId = c.Int(nullable: false, identity: true),
                        WasteCategoryName = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WasteCategoryId);
            
            DropForeignKey("dbo.Reasons", "Verlustart_VerlustartId", "dbo.Verlustarts");
            DropIndex("dbo.Reasons", new[] { "Verlustart_VerlustartId" });
            DropColumn("dbo.Reasons", "Verlustart_VerlustartId");
            CreateIndex("dbo.WasteCategories", "UserTypeId");
            AddForeignKey("dbo.WasteCategories", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: true);
        }
    }
}
