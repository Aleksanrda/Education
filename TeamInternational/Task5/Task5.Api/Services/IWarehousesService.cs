using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;

namespace Task5.Api.Services
{
    public interface IWarehousesService
    {
        Warehouse GetWarehouseById(int id);

        IEnumerable<Warehouse> GetWarehouses();

        Warehouse Create(Warehouse warehouse);

        void Update(Warehouse warehouse);

        void Delete(int id);
    }
}
