namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyCode = c.String(),
                        CompanyName = c.String(),
                        CountryId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Plants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlantName = c.String(),
                        CompanyId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plants", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CountryId", "dbo.Countries");
            DropIndex("dbo.Plants", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "CountryId" });
            DropTable("dbo.Plants");
            DropTable("dbo.Countries");
            DropTable("dbo.Companies");
        }
    }
}
