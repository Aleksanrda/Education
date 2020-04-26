using System;
using System.Collections.Generic;
using System.Text;

namespace BabyLife.Core.Entities
{
    public class Device : Entity
    {
        public string Name { get; set; }

        public int Indicator { get; set; }

        public List<Feeding> Feedings { get; set; }
    }
}
