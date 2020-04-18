using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task5.Core.Entities
{
    public class Warehouse : Address
    {
        [Required]
        public string Name { get; set; }

        public IList<WarehouseFlower> WarehouseFlowers { get; set; }

        public IList<Supply> Supplies { get; set; }
    }
}
