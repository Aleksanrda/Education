using Creeperscare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creeperscare.API.Models
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }

        public DateTime Date { get; set; }

        public string ServiceType { get; set; }

        public int DeviceId { get; set; }

        public GardenPlotModel GardenPlot { get; set; }
    }
}
