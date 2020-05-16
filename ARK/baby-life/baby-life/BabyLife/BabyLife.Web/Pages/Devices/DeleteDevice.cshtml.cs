using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Devices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web.Pages.Devices
{
    public class DeleteDeviceModel : PageModel
    {
        private readonly IDevicesService devicesService;

        [BindProperty]
        public int Id { get; set; }

        public DeleteDeviceModel(IDevicesService devicesService)
        {
            this.devicesService = devicesService;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var result = await devicesService.DeleteDevice(Id);

            if (result == "Ok")
            {
                return RedirectToPage("/Devices/DeviceIndex");
            }

            return Page();
        }
    }
}