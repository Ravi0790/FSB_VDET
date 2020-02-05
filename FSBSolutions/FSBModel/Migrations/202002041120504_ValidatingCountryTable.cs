namespace FSBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidatingCountryTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Countries", "CountryName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Countries", "CountryName", c => c.String());
        }
    }
}
