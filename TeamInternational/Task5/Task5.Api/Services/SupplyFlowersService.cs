using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;
using Task5.Core.Repositories;

namespace Task5.Api.Services
{
    public class SupplyFlowersService : ISupplyFlowersService
    {
        private readonly IUnitOfWork unitOfWork;

        public SupplyFlowersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public SupplyFlower Create(SupplyFlower supplyFlower)
        {
            if (supplyFlower == null)
            {
                throw new ArgumentNullException(nameof(supplyFlower));
            }

            var newSupplyFlower = new SupplyFlower()
            {
                FlowerAmount = supplyFlower.FlowerAmount,
                FlowerId = supplyFlower.FlowerId,
                SupplyId = supplyFlower.SupplyId,
            };

            unitOfWork.SupplyFlowers.Create(newSupplyFlower);

            unitOfWork.SaveChanges();

            return newSupplyFlower;
        }

        public void Delete(int id)
        {
            var supplyFlower = unitOfWork.SupplyFlowers.GetByID(id);

            if (supplyFlower != null)
            {
                unitOfWork.Plantations.Delete(supplyFlower.Id);
                unitOfWork.SaveChanges();
            }
        }

        public SupplyFlower GetSupplyFlowerById(int id)
        {
            var supplyFlower = unitOfWork.SupplyFlowers.GetByID(id);
            return supplyFlower;
        }

        public IEnumerable<SupplyFlower> GetSupplyFlowers()
        {
            var supplyFlowers = unitOfWork.SupplyFlowers.GetAll();
            return supplyFlowers;
        }

        public void Update(SupplyFlower supply)
        {
            var updateSupply = unitOfWork.SupplyFlowers.GetByID(supply.Id);

            if (updateSupply == null)
            {
                throw new ArgumentException("Flower not found");
            }

            updateSupply.FlowerAmount = supply.FlowerAmount;
            updateSupply.FlowerId = supply.FlowerId;
            updateSupply.SupplyId = supply.SupplyId;

            unitOfWork.SupplyFlowers.Update(updateSupply);
            unitOfWork.SaveChanges();
        }
    }
}
