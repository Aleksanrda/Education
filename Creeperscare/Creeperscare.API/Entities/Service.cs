using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creeperscare.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }

        public DateTime Date { get; set; }

        public string ServiceType { get; set; }

        public int DeviceId { get; set; }

        public Device Device { get; set; }

        public int GardenPlotId { get; set; }

        public GardenPlot GetGardenPlot { get; set; }
    }
}
