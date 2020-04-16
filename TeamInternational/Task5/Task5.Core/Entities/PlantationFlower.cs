using System;
using System.Collections.Generic;
using System.Text;

namespace Task5.Core.Entities
{
    public class PlantationFlower : Amount
    {
        public int FlowerId { get; set; }

        public Flower Flower { get; set; }

        public int PlantationId { get; set; }

        public Plantation Plantation { get; set; }
    }
}
