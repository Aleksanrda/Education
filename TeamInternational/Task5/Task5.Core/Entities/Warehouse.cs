using System;
using System.Collections.Generic;
using System.Text;

namespace Task5.Core.Entities
{
    public class Warehouse : Address
    {
        public string Name { get; set; }

        public IList<WarehouseFlower> WarehouseFlowers { get; set; }

        public IList<Supply> Supplies { get; set; }
    }
}
