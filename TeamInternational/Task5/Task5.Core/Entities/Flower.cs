using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task5.Core.Entities
{
    public class Flower : Entity
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name length cannot be bigger 15 and not shorter than 3 symbols ")]
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<WarehouseFlower> WarehouseFlowers { get; set; }

        public IList<PlantationFlower> PlantationFlowers { get; set; }

        public IList<SupplyFlower> SupplyFlowers { get; set; }
    }
}
