using System;
using System.Collections.Generic;
using System.Text;

namespace Task5.Core.Entities
{
    public class WarehouseFlower : Amount
    {
        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        public int FlowerId { get; set; }

        public Flower Flower { get; set; }
    }
}
