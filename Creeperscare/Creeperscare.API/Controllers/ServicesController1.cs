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
    public class ServicesController1 : ControllerBase
    {
        private readonly CreeperscareDbContext _context;

        public ServicesController1(CreeperscareDbContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        [ProducesResponseType(typeof(ServiceModel[]), StatusCodes.Status200OK)]
        public IEnumerable<ServiceModel> GetServices()
        {
            var serviceModels = _context.Services.Select(x =>
            new ServiceModel()
            {
                ServiceId = x.ServiceId,
                Date = x.Date,
                ServiceType = x.ServiceType,
                DeviceId = x.DeviceId,
                GardenPlot = new GardenPlotModel()
                {
                    GardenPlotId = x.GardenPlot.GardenPlotId,
                    Width = x.GardenPlot.Width,
                    Length = x.GardenPlot.Length
                }
            });

            return serviceModels;
        }

        // GET api/Services/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServiceModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> GetService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            var cleaningModel = new ServiceModel()
            {
                ServiceId = service.ServiceId,
                Date = service.Date,
                ServiceType = service.ServiceType,
                DeviceId = service.DeviceId,
                GardenPlot = new GardenPlotModel()
                {
                    GardenPlotId = service.GardenPlot.GardenPlotId,
                    Width = service.GardenPlot.Width,
                    Length = service.GardenPlot.Length
                }
            };

            return Ok(cleaningModel);
        }

        // POST api/Services
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostService([FromBody] ServiceModel serviceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = new Service()
            {
                Date = serviceModel.Date,
                ServiceType = serviceModel.ServiceType,
                DeviceId = serviceModel.DeviceId,
                GardenPlotId = serviceModel.GardenPlot.GardenPlotId
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = serviceModel.ServiceId }, service);
        }

        // PUT api/Services/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService([FromRoute] int id, [FromBody] ServiceModel serviceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceModel.ServiceId)
            {
                return BadRequest();
            }

            var service = await _context.Services.FindAsync(serviceModel.ServiceId);

            service.Date = serviceModel.Date;
            service.ServiceType = serviceModel.ServiceType;           
            service.DeviceId = serviceModel.DeviceId;
            service.GardenPlotId = serviceModel.GardenPlot.GardenPlotId;

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // DELETE api/Services/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Service), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteService([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return Ok(service);
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.ServiceId == id);
        }
    }
}
