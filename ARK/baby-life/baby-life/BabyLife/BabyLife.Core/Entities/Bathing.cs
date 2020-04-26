using System;
using System.Collections.Generic;
using System.Text;

namespace BabyLife.Core.Entities
{
    public class Bathing : Entity
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int WaterTemperature { get; set; }

        public int BabyId { get; set; }

        public Baby Baby { get; set; }
    }
}
