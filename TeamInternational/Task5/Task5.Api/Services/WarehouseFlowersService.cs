using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;
using Task5.Core.Repositories;

namespace Task5.Api.Services
{
    public class WarehouseFlowersService : IWarehouseFlowersService
    {
        private readonly IUnitOfWork unitOfWork;

        public WarehouseFlowersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public WarehouseFlower Create(WarehouseFlower warehouseFlower)
        {
            if (warehouseFlower == null)
            {
                throw new ArgumentNullException(nameof(warehouseFlower));
            }

            var newWarehouseFlower = new WarehouseFlower()
            {
                FlowerAmount = warehouseFlower.FlowerAmount,
                FlowerId = warehouseFlower.FlowerId,
                WarehouseId = warehouseFlower.WarehouseId,
            };

            unitOfWork.WarehouseFlowers.Create(newWarehouseFlower);

            unitOfWork.SaveChanges();

            return newWarehouseFlower;
        }

        public void Delete(int id)
        {
            var warehouseFlower = unitOfWork.WarehouseFlowers.GetByID(id);

            if (warehouseFlower != null)
            {
                unitOfWork.Warehouses.Delete(warehouseFlower.Id);
                unitOfWork.SaveChanges();
            }
        }

        public WarehouseFlower GetWarehouseFlowerById(int id)
        {
            var warehouseFlower = unitOfWork.WarehouseFlowers.GetByID(id);

            if (warehouseFlower == null)
            {
                throw new ArgumentNullException(nameof(warehouseFlower));
            }

            return warehouseFlower;
        }

        public IEnumerable<WarehouseFlower> GetWarehouseFlowers()
        {
            var warehouseFlowers = unitOfWork.WarehouseFlowers.GetAll();

            return warehouseFlowers;
        }

        public void Update(WarehouseFlower warehouseFlower)
        {
            var updateWarehouseFlower = unitOfWork.WarehouseFlowers.GetByID(warehouseFlower.Id);

            if (updateWarehouseFlower == null)
            {
                throw new ArgumentNullException(nameof(warehouseFlower));
            }

            updateWarehouseFlower.FlowerAmount = warehouseFlower.FlowerAmount;
            updateWarehouseFlower.FlowerId = warehouseFlower.FlowerId;
            updateWarehouseFlower.WarehouseId = warehouseFlower.WarehouseId;

            unitOfWork.WarehouseFlowers.Update(updateWarehouseFlower);
            unitOfWork.SaveChanges();
        }
    }
}
