namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVerlustTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Verlusts",
                c => new
                    {
                        VerlustId = c.Int(nullable: false, identity: true),
                        VerlustName = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VerlustId)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Verlusts", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.Verlusts", new[] { "UserTypeId" });
            DropTable("dbo.Verlusts");
        }
    }
}
