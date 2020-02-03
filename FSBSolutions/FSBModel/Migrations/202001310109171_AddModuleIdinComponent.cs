namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModuleIdinComponent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Components", "ModuleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Components", "ModuleId");
            AddForeignKey("dbo.Components", "ModuleId", "dbo.Modules", "ModuleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Components", "ModuleId", "dbo.Modules");
            DropIndex("dbo.Components", new[] { "ModuleId" });
            DropColumn("dbo.Components", "ModuleId");
        }
    }
}
