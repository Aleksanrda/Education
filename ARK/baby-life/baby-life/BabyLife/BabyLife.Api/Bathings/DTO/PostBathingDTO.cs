using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabyLife.Api.Bathings.DTO
{
    public class PostBathingDTO
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int WaterTemperature { get; set; }
    }
}
