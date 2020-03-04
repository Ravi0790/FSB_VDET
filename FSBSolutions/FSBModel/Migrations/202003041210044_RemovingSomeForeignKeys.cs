namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingSomeForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WasteDetails", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.WasteDetails", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.WasteDetails", "MachineId", "dbo.Machines");
            DropForeignKey("dbo.WasteDetails", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.WasteDetails", "PartId", "dbo.Parts");
            DropForeignKey("dbo.WasteDetails", "ReasonId", "dbo.Reasons");
            DropForeignKey("dbo.WasteDetails", "VerlustId", "dbo.Verlusts");
            DropForeignKey("dbo.WasteDetails", "VerlustartId", "dbo.Verlustarts");
            DropForeignKey("dbo.WasteDetails", "WasteTypeId", "dbo.WasteTypes");
            DropIndex("dbo.WasteDetails", new[] { "WasteTypeId" });
            DropIndex("dbo.WasteDetails", new[] { "VerlustId" });
            DropIndex("dbo.WasteDetails", new[] { "VerlustartId" });
            DropIndex("dbo.WasteDetails", new[] { "LocationId" });
            DropIndex("dbo.WasteDetails", new[] { "MachineId" });
            DropIndex("dbo.WasteDetails", new[] { "ModuleId" });
            DropIndex("dbo.WasteDetails", new[] { "ComponentId" });
            DropIndex("dbo.WasteDetails", new[] { "PartId" });
            DropIndex("dbo.WasteDetails", new[] { "ReasonId" });
            DropColumn("dbo.WasteDetails", "WasteTypeId");
            DropColumn("dbo.WasteDetails", "VerlustId");
            DropColumn("dbo.WasteDetails", "VerlustartId");
            DropColumn("dbo.WasteDetails", "LocationId");
            DropColumn("dbo.WasteDetails", "MachineId");
            DropColumn("dbo.WasteDetails", "ModuleId");
            DropColumn("dbo.WasteDetails", "ComponentId");
            DropColumn("dbo.WasteDetails", "PartId");
            DropColumn("dbo.WasteDetails", "ReasonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WasteDetails", "ReasonId", c => c.Int(nullable: false));
            AddColumn("dbo.WasteDetails", "PartId", c => c.Int(nullable: false));
            AddColumn("dbo.WasteDetails", "ComponentId", c => c.Int(nullable: false));
            AddColumn("dbo.WasteDetails", "ModuleId", c => c.Int(nullable: false));
            AddColumn("dbo.WasteDetails", "MachineId", c => c.Int(nullable: false));
            AddColumn("dbo.WasteDetails", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.WasteDetails", "VerlustartId", c => c.Int(nullable: false));
            AddColumn("dbo.WasteDetails", "VerlustId", c => c.Int(nullable: false));
            AddColumn("dbo.WasteDetails", "WasteTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.WasteDetails", "ReasonId");
            CreateIndex("dbo.WasteDetails", "PartId");
            CreateIndex("dbo.WasteDetails", "ComponentId");
            CreateIndex("dbo.WasteDetails", "ModuleId");
            CreateIndex("dbo.WasteDetails", "MachineId");
            CreateIndex("dbo.WasteDetails", "LocationId");
            CreateIndex("dbo.WasteDetails", "VerlustartId");
            CreateIndex("dbo.WasteDetails", "VerlustId");
            CreateIndex("dbo.WasteDetails", "WasteTypeId");
            AddForeignKey("dbo.WasteDetails", "WasteTypeId", "dbo.WasteTypes", "WasteTypeId", cascadeDelete: true);
            AddForeignKey("dbo.WasteDetails", "VerlustartId", "dbo.Verlustarts", "VerlustartId", cascadeDelete: true);
            AddForeignKey("dbo.WasteDetails", "VerlustId", "dbo.Verlusts", "VerlustId", cascadeDelete: true);
            AddForeignKey("dbo.WasteDetails", "ReasonId", "dbo.Reasons", "ReasonId", cascadeDelete: true);
            AddForeignKey("dbo.WasteDetails", "PartId", "dbo.Parts", "PartId", cascadeDelete: true);
            AddForeignKey("dbo.WasteDetails", "ModuleId", "dbo.Modules", "ModuleId", cascadeDelete: true);
            AddForeignKey("dbo.WasteDetails", "MachineId", "dbo.Machines", "MachineId", cascadeDelete: true);
            AddForeignKey("dbo.WasteDetails", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: true);
            AddForeignKey("dbo.WasteDetails", "ComponentId", "dbo.Components", "ComponentId", cascadeDelete: true);
        }
    }
}
