using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.DiaperChanges;
using BabyLife.Api.DiaperChanges.DTO;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabyLife.Mobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaperChangesController : ControllerBase
    {
        private readonly IDiaperChangesService diaperChangesService;

        public DiaperChangesController(IDiaperChangesService diaperChangesService)
        {
            this.diaperChangesService = diaperChangesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostDiaperChanges[]), StatusCodes.Status200OK)]
        public IEnumerable<PostDiaperChanges> GetDiaperChanges()
        {
            var result = diaperChangesService.GetDiaperChanges();

            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostDiaperChanges), StatusCodes.Status200OK)]
        public IActionResult GetDiaperChange([FromRoute] int id)
        {
            var result = diaperChangesService.GetDiaperChange(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostDiaperChange([FromBody] PostDiaperChanges postDiaperChangesDTO)
        {
            var result = await diaperChangesService.CreateDiaperChange(postDiaperChangesDTO);

            if (result == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetDiaperChange", new { id = result.Id }, postDiaperChangesDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaperChange([FromRoute] int id, [FromBody] PostDiaperChanges postDiaperChangesDTO)
        {
            var result = await diaperChangesService.UpdateDiaperChange(id, postDiaperChangesDTO);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DiaperChange), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteDiaperChange([FromRoute] int id)
        {
            var result = await diaperChangesService.DeleteDiaperChange(id);

            if (result == "Error")
            {
                return NotFound();
            }

            return Ok();
        }
    }
}