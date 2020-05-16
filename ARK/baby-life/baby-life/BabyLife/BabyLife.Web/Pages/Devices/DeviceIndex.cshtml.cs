using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Devices;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class DeviceIndexModel : PageModel
    {
        private readonly IDevicesService devicesService;

        public List<Device> Devices { get; set; }

        public DeviceIndexModel(IDevicesService devicesService)
        {
            this.devicesService = devicesService;
        }

        public void OnGet()
        {
            Devices = devicesService.GetDevices().ToList();
        }
    }
}