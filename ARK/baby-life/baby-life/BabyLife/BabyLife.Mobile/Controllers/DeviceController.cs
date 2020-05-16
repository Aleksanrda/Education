using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Devices;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabyLife.Mobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDevicesService devicesService;

        public DeviceController(IDevicesService devicesService)
        {
            this.devicesService = devicesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Device[]), StatusCodes.Status200OK)]
        public IEnumerable<Device> GetDevices()
        {
            var result = devicesService.GetDevices();

            return result;
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(Device), StatusCodes.Status200OK)]
        //public IActionResult GetDevice([FromRoute] int id)
        //{
        //    var result = devicesService.GetDevice(id);

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostDevice([FromBody] Device device)
        {
            var result = await devicesService.CreateDevice(device);

            if (result == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetDevice", new { id = result.Id }, device);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice([FromRoute] int id, [FromBody] Device device)
        {
            var result = await devicesService.UpdateDevice(device);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Device), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteDevice([FromRoute] int id)
        {
            var result = await devicesService.DeleteDevice(id);

            if (result == "Error")
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(bool[]), StatusCodes.Status200OK)]
        public IActionResult GetIsFeedingBaby([FromRoute] int id, [FromBody] Feeding feeding)
        {
            var result = devicesService.IsFeedingBaby(feeding, id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}