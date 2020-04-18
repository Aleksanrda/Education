using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;
using Task5.Core.Repositories;

namespace Task5.Api.Services
{
    public class SuppliesService : ISuppliesService
    {
        private readonly IUnitOfWork unitOfWork;

        public SuppliesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Supply Create(Supply supply)
        {
            if (supply == null)
            {
                throw new ArgumentNullException(nameof(supply));
            }

            var newSupply = new Supply()
            {
                PlantationId = supply.PlantationId,
                WarehouseId = supply.WarehouseId,
                ScheduledData = supply.ScheduledData,
                ClosedData = supply.ClosedData,
                Status = supply.Status,
                SupplyFlowers = supply.SupplyFlowers,
            };

            unitOfWork.Supplies.Create(newSupply);

            unitOfWork.SaveChanges();

            return newSupply;
        }

        public void Delete(int id)
        {
            var supply = unitOfWork.Supplies.GetByID(id);

            if (supply != null)
            {
                unitOfWork.Supplies.Delete(supply);
                unitOfWork.SaveChanges();
            }
        }

        public IEnumerable<Supply> GetSupplies()
        {
            var supplies = unitOfWork.Supplies.GetAll();
            return supplies;
        }

        public Supply GetSupplyById(int id)
        {
            var supply = unitOfWork.Supplies.GetByID(id);
            return supply;
        }

        public void Update(Supply supply)
        {
            var updateSupply = unitOfWork.Supplies.GetByID(supply.Id);

            if (updateSupply == null)
            {
                throw new ArgumentException("Supply not found");
            }

            updateSupply.PlantationId = supply.PlantationId;
            updateSupply.WarehouseId = supply.WarehouseId;
            updateSupply.ScheduledData = supply.ScheduledData;
            updateSupply.ClosedData = supply.ClosedData;
            updateSupply.Status = supply.Status;

            unitOfWork.Supplies.Update(updateSupply);
            unitOfWork.SaveChanges();
        }
    }
}
