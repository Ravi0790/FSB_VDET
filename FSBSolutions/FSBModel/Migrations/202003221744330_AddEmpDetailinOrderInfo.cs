namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpDetailinOrderInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderInfoes", "PremanentEmp", c => c.Int(nullable: false));
            AddColumn("dbo.OrderInfoes", "TemporaryEmp", c => c.Int(nullable: false));
            AddColumn("dbo.OrderInfoes", "ExternalEmp", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "PremanentEmp");
            DropColumn("dbo.OrderDetails", "TemporaryEmp");
            DropColumn("dbo.OrderDetails", "ExternalEmp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "ExternalEmp", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "TemporaryEmp", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "PremanentEmp", c => c.Int(nullable: false));
            DropColumn("dbo.OrderInfoes", "ExternalEmp");
            DropColumn("dbo.OrderInfoes", "TemporaryEmp");
            DropColumn("dbo.OrderInfoes", "PremanentEmp");
        }
    }
}
