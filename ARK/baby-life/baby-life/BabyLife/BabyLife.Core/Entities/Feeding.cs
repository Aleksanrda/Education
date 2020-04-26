using System;
using System.Collections.Generic;
using System.Text;

namespace BabyLife.Core.Entities
{
    public class Feeding : Entity
    {

        public string Name { get; set; }

        public int CountMilk { get; set; }

        public DateTime TimeMilk { get; set; }

        public int DeviceId { get; set; }

        public Device Device { get; set; }

        public int BabyId { get; set; }

        public Baby Baby { get; set; }
    }
}
