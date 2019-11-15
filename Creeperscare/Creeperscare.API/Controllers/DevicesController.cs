using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creeperscare.API.Models;
using Creeperscare.DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
