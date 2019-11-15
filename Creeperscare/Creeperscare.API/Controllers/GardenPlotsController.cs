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
    public class GardenPlotsController : ControllerBase
    {
        private readonly CreeperscareDbContext _context;

        public GardenPlotsController(CreeperscareDbContext context)
        {
            _context = context;
        }

        // GET: api/GardenPlots
        [HttpGet]
        [ProducesResponseType(typeof(GardenPlotModel[]), StatusCodes.Status200OK)]
        public IEnumerable<GardenPlotModel> GetGardenPlots()
        {
            var gardenPlotsModel = _context.GardenPlots.Select(x =>
            new GardenPlotModel()
            {
                GardenPlotId = x.GardenPlotId,
                Length = x.Length,
                Width = x.Width
            }).ToList();

            return gardenPlotsModel;
        }

        // GET: api/GardenPlots/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GardenPlotModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGardenPlot([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gardenPlot = await _context.GardenPlots.FindAsync(id);

            if (gardenPlot == null)
            {
                return NotFound();
            }

            var gardenPlotModel = new GardenPlotModel()
            {
                GardenPlotId = gardenPlot.GardenPlotId,
                Length = gardenPlot.Length,
                Width = gardenPlot.Width
            };

            return Ok(gardenPlotModel);
        }

        // PUT: api/GardenPlos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGardenPlot([FromRoute] int id, [FromBody] GardenPlotModel gardenPlotModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gardenPlotModel.GardenPlotId)
            {
                return BadRequest();
            }

            var gardenPlot = await _context.GardenPlots.FindAsync(gardenPlotModel.GardenPlotId);
            gardenPlot.Length = gardenPlotModel.Length;
            gardenPlot.Width = gardenPlotModel.Width;

            _context.Entry(gardenPlot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GardenPlotExists(id))
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

        // POST: api/GardenPlots
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostGardenPlot([FromBody] GardenPlotModel gardenPlotModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var gardenPlot = new GardenPlot()
            {
                Length = gardenPlotModel.Length,
                Width = gardenPlotModel.Width
            };

            _context.GardenPlots.Add(gardenPlot);
            await _context.SaveChangesAsync();
            gardenPlotModel.GardenPlotId = gardenPlot.GardenPlotId;

            return CreatedAtAction("GetGardenPlot", new { id = gardenPlotModel.GardenPlotId }, gardenPlotModel);
        }

        // DELETE: api/GardenPlots/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(GardenPlot), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteGardenPlot([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gardenPlot = await _context.GardenPlots.FindAsync(id);
            if (gardenPlot == null)
            {
                return NotFound();
            }

            _context.GardenPlots.Remove(gardenPlot);
            await _context.SaveChangesAsync();

            return Ok(gardenPlot);
        }

        private bool GardenPlotExists(int id)
        {
            return _context.GardenPlots.Any(e => e.GardenPlotId == id);
        }
    }
}
