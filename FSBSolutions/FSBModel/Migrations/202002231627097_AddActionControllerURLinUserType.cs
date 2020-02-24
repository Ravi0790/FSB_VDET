namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActionControllerURLinUserType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTypes", "LoginActionURL", c => c.String(maxLength: 100));
            AddColumn("dbo.UserTypes", "LoginControllerURL", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserTypes", "LoginControllerURL");
            DropColumn("dbo.UserTypes", "LoginActionURL");
        }
    }
}
