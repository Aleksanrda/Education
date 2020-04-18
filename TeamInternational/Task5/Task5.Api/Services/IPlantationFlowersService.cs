using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;

namespace Task5.Api.Services
{
    public interface IPlantationFlowersService
    {
        PlantationFlower GetPlantationFlowerById(int id);

        IEnumerable<PlantationFlower> GetPlantationFlowers();

        PlantationFlower Create(PlantationFlower plantationFlower);

        void Update(PlantationFlower plantationFlower);

        void Delete(int id);
    }
}
