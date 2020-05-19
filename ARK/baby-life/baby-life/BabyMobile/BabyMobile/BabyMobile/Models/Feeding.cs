using System;
using System.Collections.Generic;
using System.Text;

namespace BabyMobile.Models
{
    public class Feeding
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountMilk { get; set; }

        public DateTime TimeMilk { get; set; }

        public int DeviceId { get; set; }
    }
}
