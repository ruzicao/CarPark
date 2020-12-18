namespace CarPark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.Manufacturers", "Address", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Manufacturers", "Address", c => c.String());
            DropColumn("dbo.Cars", "Year");
        }
    }
}
