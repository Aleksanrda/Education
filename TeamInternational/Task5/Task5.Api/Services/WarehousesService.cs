using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;
using Task5.Core.Repositories;

namespace Task5.Api.Services
{
    public class WarehousesService : IWarehousesService
    {
        private readonly IUnitOfWork unitOfWork;

        public WarehousesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Warehouse Create(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                throw new ArgumentNullException(nameof(warehouse));
            }

            var newWarehouse = new Warehouse()
            {
                Name = warehouse.Name,
                AddressPlace = warehouse.AddressPlace,
                Supplies = warehouse.Supplies,
                WarehouseFlowers = warehouse.WarehouseFlowers,
            };

            unitOfWork.Warehouses.Create(newWarehouse);

            unitOfWork.SaveChanges();

            return newWarehouse;
        }

        public void Delete(int id)
        {
            var warehouse = unitOfWork.Warehouses.GetByID(id);

            if (warehouse != null)
            {
                unitOfWork.Warehouses.Delete(warehouse);
                unitOfWork.SaveChanges();
            }
        }

        public Warehouse GetWarehouseById(int id)
        {
            var warehouse = unitOfWork.Warehouses.GetByID(id);
            return warehouse;
        }

        public IEnumerable<Warehouse> GetWarehouses()
        {
            var warehouses = unitOfWork.Warehouses.GetAll();
            return warehouses;
        }

        public void Update(Warehouse warehouse)
        {
            var updateWarehouse = unitOfWork.Warehouses.GetByID(warehouse.Id);

            if (updateWarehouse == null)
            {
                throw new ArgumentException("Warehouse not found");
            }

            updateWarehouse.Name = warehouse.Name;
            updateWarehouse.AddressPlace = warehouse.AddressPlace;

            unitOfWork.Warehouses.Update(updateWarehouse);
            unitOfWork.SaveChanges();
        }
    }
}
