using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creeperscare.Entities
{
    public class GardenPlot
    {
        public int GardenPlotId { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public List<Service> DeviceServices { get; set; }

        public GardenPlot()
        {
            DeviceServices = new List<Service>();
        }
    }
}
