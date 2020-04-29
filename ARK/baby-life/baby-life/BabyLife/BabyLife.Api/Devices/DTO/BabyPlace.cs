using System;
using System.Collections.Generic;
using System.Text;

namespace BabyLife.Api.Devices.DTO
{
    public class BabyPlace
    {
        public int BabyId { get; set; }

        public double Longtitude { get; set; }

        public double latitude { get; set; }

        public int DeviceId { get; set; }
    }
}
