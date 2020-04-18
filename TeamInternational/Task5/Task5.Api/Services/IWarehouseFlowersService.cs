using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;

namespace Task5.Api.Services
{
    public interface IWarehouseFlowersService
    {
        WarehouseFlower GetWarehouseFlowerById(int id);

        IEnumerable<WarehouseFlower> GetWarehouseFlowers();

        WarehouseFlower Create(WarehouseFlower warehouseFlower);

        void Update(WarehouseFlower warehouseFlower);

        void Delete(int id);
    }
}
