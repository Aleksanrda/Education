namespace Task5.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewField : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlantationFlowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlowerId = c.Int(nullable: false),
                        PlantationId = c.Int(nullable: false),
                        FlowerAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flowers", t => t.FlowerId, cascadeDelete: true)
                .ForeignKey("dbo.Plantations", t => t.PlantationId, cascadeDelete: true)
                .Index(t => t.FlowerId)
                .Index(t => t.PlantationId);
            
            CreateTable(
                "dbo.Plantations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressPlace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlantationId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        ScheduledData = c.DateTime(nullable: false),
                        ClosedData = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plantations", t => t.PlantationId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.PlantationId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.SupplyFlowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlowerId = c.Int(nullable: false),
                        SupplyId = c.Int(nullable: false),
                        FlowerAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flowers", t => t.FlowerId, cascadeDelete: true)
                .ForeignKey("dbo.Supplies", t => t.SupplyId, cascadeDelete: true)
                .Index(t => t.FlowerId)
                .Index(t => t.SupplyId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressPlace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WarehouseFlowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseId = c.Int(nullable: false),
                        FlowerId = c.Int(nullable: false),
                        FlowerAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flowers", t => t.FlowerId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId)
                .Index(t => t.FlowerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarehouseFlowers", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseFlowers", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.Supplies", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.SupplyFlowers", "SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.SupplyFlowers", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.Supplies", "PlantationId", "dbo.Plantations");
            DropForeignKey("dbo.PlantationFlowers", "PlantationId", "dbo.Plantations");
            DropForeignKey("dbo.PlantationFlowers", "FlowerId", "dbo.Flowers");
            DropIndex("dbo.WarehouseFlowers", new[] { "FlowerId" });
            DropIndex("dbo.WarehouseFlowers", new[] { "WarehouseId" });
            DropIndex("dbo.SupplyFlowers", new[] { "SupplyId" });
            DropIndex("dbo.SupplyFlowers", new[] { "FlowerId" });
            DropIndex("dbo.Supplies", new[] { "WarehouseId" });
            DropIndex("dbo.Supplies", new[] { "PlantationId" });
            DropIndex("dbo.PlantationFlowers", new[] { "PlantationId" });
            DropIndex("dbo.PlantationFlowers", new[] { "FlowerId" });
            DropTable("dbo.WarehouseFlowers");
            DropTable("dbo.Warehouses");
            DropTable("dbo.SupplyFlowers");
            DropTable("dbo.Supplies");
            DropTable("dbo.Plantations");
            DropTable("dbo.PlantationFlowers");
            DropTable("dbo.Flowers");
        }
    }
}
