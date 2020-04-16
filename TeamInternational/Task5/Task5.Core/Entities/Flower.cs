using System;
using System.Collections.Generic;
using System.Text;

namespace Task5.Core.Entities
{
    public class Flower : Entity
    {
        public string Name { get; set; }

        public IList<WarehouseFlower> WarehouseFlowers { get; set; }

        public IList<PlantationFlower> PlantationFlowers { get; set; }

        public IList<SupplyFlower> SupplyFlowers { get; set; }
    }
}
