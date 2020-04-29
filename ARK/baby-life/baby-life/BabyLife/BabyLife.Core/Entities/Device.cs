using System;
using System.Collections.Generic;
using System.Text;

namespace BabyLife.Core.Entities
{
    public class Device : Entity
    {
        public string Name { get; set; }

        public int Indicator { get; set; }

        public int ActionRange { get; set; }

        public int MaxVolume { get; set; }

        public int MaxWeight { get; set; }

        public int Longtitude { get; set; }

        public int Latitude { get; set; }

        public List<Feeding> Feedings { get; set; }
    }
}
