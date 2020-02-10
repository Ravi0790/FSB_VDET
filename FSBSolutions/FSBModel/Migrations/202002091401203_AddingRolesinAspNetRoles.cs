namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRolesinAspNetRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetRoles VALUES  (1,'superadmin')");
            Sql("INSERT INTO AspNetRoles VALUES  (2,'admin')");
            Sql("INSERT INTO AspNetRoles VALUES  (3,'user')");
        }
        
        public override void Down()
        {
        }
    }
}
