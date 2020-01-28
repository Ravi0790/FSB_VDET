namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesLocationToParts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        MachineId = c.Int(nullable: false, identity: true),
                        MachineName = c.String(),
                        Status = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineId)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        Status = c.Boolean(nullable: false),
                        MachineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleId)
                .ForeignKey("dbo.Machines", t => t.MachineId, cascadeDelete: true)
                .Index(t => t.MachineId);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        ComponentId = c.Int(nullable: false, identity: true),
                        ComponentName = c.String(),
                        Status = c.Boolean(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        Module_MachineId = c.Int(),
                    })
                .PrimaryKey(t => t.ComponentId)
                .ForeignKey("dbo.Machines", t => t.Module_MachineId)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.Module_MachineId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        PartName = c.String(),
                        Status = c.Boolean(nullable: false),
                        ComponentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .Index(t => t.ComponentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "MachineId", "dbo.Machines");
            DropForeignKey("dbo.Components", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Parts", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.Components", "Module_MachineId", "dbo.Machines");
            DropForeignKey("dbo.Machines", "LocationId", "dbo.Locations");
            DropIndex("dbo.Parts", new[] { "ComponentId" });
            DropIndex("dbo.Components", new[] { "Module_MachineId" });
            DropIndex("dbo.Components", new[] { "ModuleId" });
            DropIndex("dbo.Modules", new[] { "MachineId" });
            DropIndex("dbo.Machines", new[] { "LocationId" });
            DropTable("dbo.Parts");
            DropTable("dbo.Components");
            DropTable("dbo.Modules");
            DropTable("dbo.Machines");
        }
    }
}
