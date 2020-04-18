using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task5.Core.Entities
{
    public class Supply : Entity
    {
        public int PlantationId { get; set; }

        public Plantation Plantation { get; set; }

        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ScheduledData { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ClosedData { get; set; }

        [Required]
        public Status Status { get; set; }

        public IList<SupplyFlower> SupplyFlowers { get; set; }
    }
}
