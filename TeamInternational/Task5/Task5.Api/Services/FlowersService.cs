using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;
using Task5.Core.Repositories;

namespace Task5.Api.Services
{
    public class FlowersService : IFlowersService
    {
        private readonly IUnitOfWork unitOfWork;

        public FlowersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(Flower flower)
        {
            if (flower == null)
            {
                throw new ArgumentNullException(nameof(flower));
            }

            var newFlower = new Flower()
            {
                Name = flower.Name,
                Description = flower.Description,
                SupplyFlowers = flower.SupplyFlowers,
                WarehouseFlowers = flower.WarehouseFlowers,
                PlantationFlowers = flower.PlantationFlowers,
            };

            unitOfWork.Flowers.Create(newFlower);

            unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var flower = unitOfWork.Flowers.GetByID(id);

            if (flower != null)
            {
                unitOfWork.Flowers.Delete(flower);
                unitOfWork.SaveChanges();
            }
        }

        public Flower GetFlowerById(int id)
        {
            var flower = unitOfWork.Flowers.GetByID(id);
            return flower;
        }

        public IEnumerable<Flower> GetFlowers()
        {
            var flowers = unitOfWork.Flowers.GetAll();
            return flowers;
        }

        public void Update(Flower flowerParam)
        {
            var flower = unitOfWork.Flowers.GetByID(flowerParam.Id);

            if (flower == null)
            {
                throw new ArgumentException("Flower not found");
            }

            flower.Name = flowerParam.Name;
            flower.Description = flowerParam.Description;

            unitOfWork.Flowers.Update(flower);
            unitOfWork.SaveChanges();
        }
    }
}
