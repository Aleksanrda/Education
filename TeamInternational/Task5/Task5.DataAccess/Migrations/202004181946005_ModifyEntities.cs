namespace Task5.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyEntities : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flowers", "Name", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Plantations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Plantations", "AddressPlace", c => c.String(nullable: false));
            AlterColumn("dbo.Warehouses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Warehouses", "AddressPlace", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Warehouses", "AddressPlace", c => c.String());
            AlterColumn("dbo.Warehouses", "Name", c => c.String());
            AlterColumn("dbo.Plantations", "AddressPlace", c => c.String());
            AlterColumn("dbo.Plantations", "Name", c => c.String());
            AlterColumn("dbo.Flowers", "Name", c => c.String(nullable: false));
        }
    }
}
