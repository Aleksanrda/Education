using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;

namespace Task5.Api.Services
{
    public interface IFlowersService
    {
        Flower GetFlowerById(int id);

        IEnumerable<Flower> GetFlowers();

        void Create(Flower flowerParam);

        void Update(Flower flowerParam);

        void Delete(int id);
    }
}
