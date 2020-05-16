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
    public class CreateDeviceModel : PageModel
    {
        private readonly IDevicesService devicesService;

        public CreateDeviceModel(IDevicesService devicesService)
        {
            this.devicesService = devicesService;
        }

        [BindProperty]
        public Device NewDevice { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await devicesService.CreateDevice(NewDevice);

                if (result != null)
                {
                    return RedirectToPage("/Devices/DeviceIndex");
                }
                else
                {
                    return Page();
                }
            }
            return Page();
        }
    }
}
