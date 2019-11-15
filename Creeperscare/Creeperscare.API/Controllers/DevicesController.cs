using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creeperscare.API.Models;
using Creeperscare.DAL.Services;
using Creeperscare.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Creeperscare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly CreeperscareDbContext _context;

        public DevicesController(CreeperscareDbContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        [ProducesResponseType(typeof(DeviceModel[]), StatusCodes.Status200OK)]
        public IEnumerable<DeviceModel> GetDevices()
        {
            var deviceModels = _context.Devices.Select(x =>
            new DeviceModel()
            {
                DeviceId = x.DeviceId,
                ActionRange = x.ActionRange,
                Humidity = x.Humidity,
                Temperature = x.Temperature,
                Owner = new UserModel()
                {
                    UserId = x.Owner.Id,
                    Email = x.Owner.Email,
                    Name = x.Owner.UserName,
                    Role = x.Owner.Role
                }
            }).ToList();

            return deviceModels;
        }

        // GET api/Devices/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DeviceModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDevice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var device = await _context.Devices.Include(x => x.Owner).Where(x => x.DeviceId == id).FirstOrDefaultAsync();

            if (device == null)
            {
                return NotFound();
            }

            var deviceModel = new DeviceModel()
            {
                DeviceId = device.DeviceId,
                ActionRange = device.ActionRange,
                Humidity = device.Humidity,
                Temperature = device.Temperature,
                Owner = new UserModel()
                {
                    UserId = device.Owner.Id,
                    Email = device.Owner.Email,
                    Name = device.Owner.UserName,
                    Role = device.Owner.Role
                }
            };

            return Ok(deviceModel);
        }

        // POST api/Devices
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostDevice([FromBody] DeviceModel deviceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var device = new Device()
            {
                ActionRange = deviceModel.ActionRange,
                Humidity = deviceModel.Humidity,
                Temperature = deviceModel.Temperature
            };

            if (deviceModel.Owner != null && this.UserExists(deviceModel.Owner.UserId))
            {
                device.OwnerId = deviceModel.Owner.UserId;
                device.Owner = await _context.ProgramUsers.FindAsync(deviceModel.Owner.UserId);
            }

            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            deviceModel.DeviceId = device.DeviceId;
            return CreatedAtAction("GetDevice", new { id = device.DeviceId }, deviceModel);
        }

        // PUT api/Devices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice([FromRoute] int id, [FromBody] DeviceModel deviceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceModel.DeviceId)
            {
                return BadRequest();
            }
            var device = await _context.Devices.FindAsync(deviceModel.DeviceId);
            device.Humidity = deviceModel.Humidity;
            device.ActionRange = deviceModel.ActionRange;
            device.Temperature = deviceModel.Temperature;
            if (deviceModel.Owner != null && this.UserExists(deviceModel.Owner.UserId))
            {
                device.OwnerId = deviceModel.Owner.UserId;
                device.Owner = await _context.ProgramUsers.FindAsync(deviceModel.Owner.UserId);
            }
            else
            {
                device.Owner = await _context.ProgramUsers.Where(x => x.Role == "admin").FirstOrDefaultAsync();
                device.OwnerId = device.Owner.Id;
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/Devices/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Device), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteDevice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return Ok(device);
        }

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.DeviceId == id);
        }

        private bool UserExists(string id)
        {
            return _context.ProgramUsers.Any(e => e.Id == id);
        }
    }
}
