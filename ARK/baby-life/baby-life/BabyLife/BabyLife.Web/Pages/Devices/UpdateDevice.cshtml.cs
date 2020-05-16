using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Devices;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web.Pages.Devices
{
    public class UpdateDeviceModel : PageModel
    {
        private readonly IDevicesService devicesService;

        [BindProperty]
        public Device EditDevice { get; set; }

        public UpdateDeviceModel(IDevicesService devicesService)
        {
            this.devicesService = devicesService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var device = devicesService.GetDevice(id);
            var result = await devicesService.UpdateDevice(device);
            EditDevice = result;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await devicesService.UpdateDevice(EditDevice);

                if (result != null)
                {
                    return RedirectToPage("/Devices/DeviceIndex");
                }
            }

            return Page();
        }
    }
}