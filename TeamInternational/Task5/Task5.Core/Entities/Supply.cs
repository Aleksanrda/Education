using System;
using System.Collections.Generic;
using System.Text;

namespace Task5.Core.Entities
{
    public class Supply : Entity
    {
        public int PlantationId { get; set; }

        public Plantation Plantation { get; set; }

        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        public DateTime ScheduledData { get; set; }

        public DateTime ClosedData { get; set; }

        public Status Status { get; set; }

        public IList<SupplyFlower> SupplyFlowers { get; set; }
    }
}
