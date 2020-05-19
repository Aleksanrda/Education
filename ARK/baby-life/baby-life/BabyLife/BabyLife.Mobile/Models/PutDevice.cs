using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Mobile.Models
{
    public class PutDevice
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int MaxVolume { get; set; }

        public int MaxWeight { get; set; }

        public int Indicator { get; set; }

        public int ActionRange { get; set; }

        public int Longtitude { get; set; }

        public int Latitude { get; set; }
    }
}
