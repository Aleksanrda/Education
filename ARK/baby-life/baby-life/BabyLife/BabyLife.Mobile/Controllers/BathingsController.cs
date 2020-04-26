using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Bathings;
using BabyLife.Api.Bathings.DTO;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabyLife.Mobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BathingsController : ControllerBase
    {
        private readonly IBathingsService bathingsService;

        public BathingsController(IBathingsService bathingsService)
        {
            this.bathingsService = bathingsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostBathingDTO[]), StatusCodes.Status200OK)]
        public IEnumerable<PostBathingDTO> GetBathings()
        {
            var result = bathingsService.GetBathings();

            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostBathingDTO), StatusCodes.Status200OK)]
        public IActionResult GetBathings([FromRoute] int id)
        {
            var result = bathingsService.GetBathing(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostBathing([FromBody] PostBathingDTO postBathingDTO)
        {
            var result = await bathingsService.CreateBathing(postBathingDTO);

            if (result == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetBathing", new { id = result.Id }, postBathingDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBathing([FromRoute] int id, [FromBody] PostBathingDTO postBathingDTO)
        {
            var result = await bathingsService.UpdateBathing(id, postBathingDTO);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Bathing), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBathing([FromRoute] int id)
        {
            var result = await bathingsService.DeleteBathing(id);

            if (result == "Error")
            {
                return NotFound();
            }

            return Ok();
        }
    }
}