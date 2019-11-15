using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creeperscare.API.Models;
using Creeperscare.DAL.Services;
using Creeperscare.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Creeperscare.API.Controllers
{
    [Route("api/[controller]")]
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
