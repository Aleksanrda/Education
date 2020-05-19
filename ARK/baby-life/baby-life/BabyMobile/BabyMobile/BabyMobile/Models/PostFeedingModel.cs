using System;
using System.Collections.Generic;
using System.Text;

namespace BabyMobile.Models
{
    public class PostFeedingModel
    {
        public string Name { get; set; }

        public int CountMilk { get; set; }

        public DateTime TimeMilk { get; set; }

        public int DeviceId { get; set; }
    }
}
