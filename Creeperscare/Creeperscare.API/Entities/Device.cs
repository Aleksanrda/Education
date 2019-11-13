using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creeperscare.Entities
{
    public class Device
    {
        public int DeviceId { get; set; }

        public double ActionRange { get; set; }

        public double Humidity { get; set; }

        public double Temperature { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }

        public List<Service> GardenPlotServices { get; set; }

        public Device()
        {
            GardenPlotServices = new List<Service>();
        }
    }
}
