using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;

namespace Task5.Api.Services
{
    public interface ISupplyFlowersService
    {
        SupplyFlower GetSupplyFlowerById(int id);

        IEnumerable<SupplyFlower> GetSupplyFlowers();

        SupplyFlower Create(SupplyFlower supplyFlower);

        void Update(SupplyFlower supplyFlower);

        void Delete(int id);
    }
}
