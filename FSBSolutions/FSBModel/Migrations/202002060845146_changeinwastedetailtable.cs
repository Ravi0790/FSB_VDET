namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeinwastedetailtable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.WasteDetails", "WasteTypeId");
            CreateIndex("dbo.WasteDetails", "VerlustId");
            CreateIndex("dbo.WasteDetails", "VerlustartId");
            CreateIndex("dbo.WasteDetails", "LocationId");
            CreateIndex("dbo.WasteDetails", "MachineId");
            CreateIndex("dbo.WasteDetails", "ModuleId");
            CreateIndex("dbo.WasteDetails", "ComponentId");
            CreateIndex("dbo.WasteDetails", "PartId");
            CreateIndex("dbo.WasteDetails", "ReasonId");
            AddForeignKey("dbo.WasteDetails", "ComponentId", "dbo.Components", "ComponentId", cascadeDelete: false);
            AddForeignKey("dbo.WasteDetails", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: false);
            AddForeignKey("dbo.WasteDetails", "MachineId", "dbo.Machines", "MachineId", cascadeDelete: false);
            AddForeignKey("dbo.WasteDetails", "ModuleId", "dbo.Modules", "ModuleId", cascadeDelete: false);
            AddForeignKey("dbo.WasteDetails", "PartId", "dbo.Parts", "PartId", cascadeDelete: false);
            AddForeignKey("dbo.WasteDetails", "ReasonId", "dbo.Reasons", "ReasonId", cascadeDelete: false);
            AddForeignKey("dbo.WasteDetails", "VerlustId", "dbo.Verlusts", "VerlustId", cascadeDelete: false);
            AddForeignKey("dbo.WasteDetails", "VerlustartId", "dbo.Verlustarts", "VerlustartId", cascadeDelete: false);
            AddForeignKey("dbo.WasteDetails", "WasteTypeId", "dbo.WasteTypes", "WasteTypeId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WasteDetails", "WasteTypeId", "dbo.WasteTypes");
            DropForeignKey("dbo.WasteDetails", "VerlustartId", "dbo.Verlustarts");
            DropForeignKey("dbo.WasteDetails", "VerlustId", "dbo.Verlusts");
            DropForeignKey("dbo.WasteDetails", "ReasonId", "dbo.Reasons");
            DropForeignKey("dbo.WasteDetails", "PartId", "dbo.Parts");
            DropForeignKey("dbo.WasteDetails", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.WasteDetails", "MachineId", "dbo.Machines");
            DropForeignKey("dbo.WasteDetails", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.WasteDetails", "ComponentId", "dbo.Components");
            DropIndex("dbo.WasteDetails", new[] { "ReasonId" });
            DropIndex("dbo.WasteDetails", new[] { "PartId" });
            DropIndex("dbo.WasteDetails", new[] { "ComponentId" });
            DropIndex("dbo.WasteDetails", new[] { "ModuleId" });
            DropIndex("dbo.WasteDetails", new[] { "MachineId" });
            DropIndex("dbo.WasteDetails", new[] { "LocationId" });
            DropIndex("dbo.WasteDetails", new[] { "VerlustartId" });
            DropIndex("dbo.WasteDetails", new[] { "VerlustId" });
            DropIndex("dbo.WasteDetails", new[] { "WasteTypeId" });
        }
    }
}
