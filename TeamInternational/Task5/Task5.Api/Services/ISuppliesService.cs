using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Entities;

namespace Task5.Api.Services
{
    public interface ISuppliesService
    {
        Supply GetSupplyById(int id);

        IEnumerable<Supply> GetSupplies();

        Supply Create(Supply supply);

        void Update(Supply supply);

        void Delete(int id);
    }
}
