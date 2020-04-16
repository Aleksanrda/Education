using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;

namespace Task5.DataAccess
{
    public class Task5DbContext : DbContext
    {
        public DbSet<Flower> Flowers { get; set; }

        public DbSet<Plantation> Plantations { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<PlantationFlower> PlantationFlowers { get; set; }

        public DbSet<WarehouseFlower> WarehouseFlowers { get; set; }

        public DbSet<SupplyFlower> SupplyFlowers { get; set; }
    }
}
