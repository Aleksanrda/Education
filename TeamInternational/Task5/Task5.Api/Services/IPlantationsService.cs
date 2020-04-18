using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;

namespace Task5.Api.Services
{
    public interface IPlantationsService
    {
        Plantation GetPlantationById(int id);

        IEnumerable<Plantation> GetPlantations();

        Plantation Create(Plantation plantation);

        void Update(Plantation plantation);

        void Delete(int id);
    }
}
