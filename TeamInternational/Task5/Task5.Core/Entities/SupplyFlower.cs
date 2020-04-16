using System;
using System.Collections.Generic;
using System.Text;

namespace Task5.Core.Entities
{
    public class SupplyFlower : Amount
    {
        public int FlowerId { get; set; }

        public Flower Flower { get; set; }

        public int SupplyId { get; set; }

        public Supply Supply { get; set; }
    }
}
