using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;
using Task5.Core.Repositories;

namespace Task5.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Task5DbContext _task5DbContext;
        private IRepository<Flower> _flowers;
        private IRepository<Plantation> _plantations;
        private IRepository<Warehouse> _warehouses;
        private IRepository<Supply> _supplies;
        private IRepository<PlantationFlower> _plantationFlowers;
        private IRepository<WarehouseFlower> _warehouseFlowers;
        private IRepository<SupplyFlower> _supplyFlowers;

        public UnitOfWork(Task5DbContext task5DbContext)
        {
            _task5DbContext = task5DbContext;
        }

        public IRepository<Flower> Flowers
        {
            get
            {
                return _flowers ??
                    (_flowers = new Repository<Flower>(_task5DbContext));
            }
        }

        public IRepository<Plantation> Plantations
        {
            get
            {
                return _plantations ??
                    (_plantations = new Repository<Plantation>(_task5DbContext));
            }
        }

        public IRepository<Warehouse> Warehouses
        {
            get
            {
                return _warehouses ??
                    (_warehouses = new Repository<Warehouse>(_task5DbContext));
            }
        }

        public IRepository<Supply> Supplies
        {
            get
            {
                return _supplies ??
                    (_supplies = new Repository<Supply>(_task5DbContext));
            }
        }

        public IRepository<PlantationFlower> PlantationFlowers
        {
            get
            {
                return _plantationFlowers ??
                    (_plantationFlowers = new Repository<PlantationFlower>(_task5DbContext));
            }
        }

        public IRepository<WarehouseFlower> WarehouseFlowers
        {
            get
            {
                return _warehouseFlowers ??
                    (_warehouseFlowers = new Repository<WarehouseFlower>(_task5DbContext));
            }
        }

        public IRepository<SupplyFlower> SupplyFlowers
        {
            get
            {
                return _supplyFlowers ??
                    (_supplyFlowers = new Repository<SupplyFlower>(_task5DbContext));
            }
        }

        public void SaveChanges()
        {
            _task5DbContext.SaveChanges();
        }
    }
}
