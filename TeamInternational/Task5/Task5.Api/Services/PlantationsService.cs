using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;
using Task5.Core.Repositories;

namespace Task5.Api.Services
{
    public class PlantationsService : IPlantationsService
    {
        private readonly IUnitOfWork unitOfWork;

        public PlantationsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Plantation Create(Plantation plantation)
        {
            if (plantation == null)
            {
                throw new ArgumentNullException(nameof(plantation));
            }

            var newPlantation = new Plantation()
            {
                Name = plantation.Name,
                AddressPlace = plantation.AddressPlace,
                PlantationFlowers = plantation.PlantationFlowers,
                Supplies = plantation.Supplies,
            };

            unitOfWork.Plantations.Create(newPlantation);

            unitOfWork.SaveChanges();

            return newPlantation;
        }

        public void Delete(int id)
        {
            var plantation = unitOfWork.Plantations.GetByID(id);

            if (plantation != null)
            {
                unitOfWork.Plantations.Delete(plantation);
                unitOfWork.SaveChanges();
            }
        }

        public Plantation GetPlantationById(int id)
        {
            var plantation = unitOfWork.Plantations.GetByID(id);
            return plantation;
        }

        public IEnumerable<Plantation> GetPlantations()
        {
            var plantations = unitOfWork.Plantations.GetAll();
            return plantations;
        }

        public void Update(Plantation plantation)
        {
            var updatePlantation = unitOfWork.Plantations.GetByID(plantation.Id);

            if (updatePlantation == null)
            {
                throw new ArgumentException("Flower not found");
            }

            updatePlantation.Name = plantation.Name;
            updatePlantation.AddressPlace = plantation.AddressPlace;
            updatePlantation.Supplies = plantation.Supplies;
            updatePlantation.PlantationFlowers = plantation.PlantationFlowers;

            unitOfWork.Plantations.Update(updatePlantation);
            unitOfWork.SaveChanges();
        }
    }
}
