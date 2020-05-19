using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Mobile.Models
{
    public class PutFeeding
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountMilk { get; set; }

        public DateTime TimeMilk { get; set; }

        public int DeviceId { get; set; }

    }
}
