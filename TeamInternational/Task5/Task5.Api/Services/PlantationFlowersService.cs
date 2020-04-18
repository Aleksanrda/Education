using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;
using Task5.Core.Repositories;

namespace Task5.Api.Services
{
    public class PlantationFlowersService : IPlantationFlowersService
    {
        private readonly IUnitOfWork unitOfWork;

        public PlantationFlowersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public PlantationFlower Create(PlantationFlower plantationFlower)
        {
            if (plantationFlower == null)
            {
                throw new ArgumentNullException(nameof(plantationFlower));
            }

            var newPlantationFlower = new PlantationFlower()
            {
                FlowerAmount = plantationFlower.FlowerAmount,
                FlowerId = plantationFlower.FlowerId,
                PlantationId = plantationFlower.PlantationId,
            };

            unitOfWork.PlantationFlowers.Create(newPlantationFlower);

            unitOfWork.SaveChanges();

            return newPlantationFlower;
        }

        public void Delete(int id)
        {
            var plantationFlower = unitOfWork.PlantationFlowers.GetByID(id);

            if (plantationFlower != null)
            {
                unitOfWork.Plantations.Delete(plantationFlower.Id);
                unitOfWork.SaveChanges();
            }
        }

        public PlantationFlower GetPlantationFlowerById(int id)
        {
            var plantationFlower = unitOfWork.PlantationFlowers.GetByID(id);

            if (plantationFlower == null)
            {
                throw new ArgumentNullException(nameof(plantationFlower));
            }

            return plantationFlower;
        }

        public IEnumerable<PlantationFlower> GetPlantationFlowers()
        {
            var plantationFlowers = unitOfWork.PlantationFlowers.GetAll();

            return plantationFlowers;
        }

        public void Update(PlantationFlower plantationFlower)
        {
            var updatePlantationFlower = unitOfWork.PlantationFlowers.GetByID(plantationFlower.Id);

            if (updatePlantationFlower == null)
            {
                throw new ArgumentNullException(nameof(plantationFlower));
            }

            updatePlantationFlower.FlowerAmount = plantationFlower.FlowerAmount;
            updatePlantationFlower.FlowerId = plantationFlower.FlowerId;
            updatePlantationFlower.PlantationId = plantationFlower.PlantationId;

            unitOfWork.PlantationFlowers.Update(updatePlantationFlower);
            unitOfWork.SaveChanges();
        }
    }
}
