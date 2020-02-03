namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteModuleIdfromComponent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Components", "Module_MachineId", "dbo.Machines");
            DropForeignKey("dbo.Components", "ModuleId", "dbo.Modules");
            DropIndex("dbo.Components", new[] { "ModuleId" });
            DropIndex("dbo.Components", new[] { "Module_MachineId" });
            DropColumn("dbo.Components", "ModuleId");
            DropColumn("dbo.Components", "Module_MachineId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Components", "Module_MachineId", c => c.Int());
            AddColumn("dbo.Components", "ModuleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Components", "Module_MachineId");
            CreateIndex("dbo.Components", "ModuleId");
            AddForeignKey("dbo.Components", "ModuleId", "dbo.Modules", "ModuleId", cascadeDelete: true);
            AddForeignKey("dbo.Components", "Module_MachineId", "dbo.Machines", "MachineId");
        }
    }
}
