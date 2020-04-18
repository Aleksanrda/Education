using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;

namespace Task5.Core.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Flower> Flowers { get; }

        IRepository<Plantation> Plantations { get; }

        IRepository<Warehouse> Warehouses { get; }

        IRepository<Supply> Supplies { get; }

        IRepository<WarehouseFlower> WarehouseFlowers { get; }

        IRepository<PlantationFlower> PlantationFlowers { get; }

        IRepository<SupplyFlower> SupplyFlowers { get; }

        void SaveChanges();
    }
}
