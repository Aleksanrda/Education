using Creeperscare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creeperscare.API.Models
{
    public class DeviceModel
    {
        public int DeviceId { get; set; }

        public double ActionRange { get; set; }

        public double Humidity { get; set; }

        public double Temperature { get; set; }

        public User Owner { get; set; }
    }
}
