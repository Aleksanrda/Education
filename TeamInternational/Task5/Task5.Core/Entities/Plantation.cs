using System;
using System.Collections.Generic;
using System.Text;

namespace Task5.Core.Entities
{
    public class Plantation : Address
    {
        public string Name { get; set; }

        public IList<PlantationFlower> PlantationFlowers { get; set; }

        public IList<Supply> Supplies { get; set; }
    }
}
