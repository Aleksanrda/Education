using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Sleepings;
using BabyLife.Api.Sleepings.DTO;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabyLife.Mobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SleepingsController : ControllerBase
    {
        private readonly ISleepingsService sleepingsService;

        public SleepingsController(ISleepingsService sleepingsService)
        {
            this.sleepingsService = sleepingsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostSleepingDTO[]), StatusCodes.Status200OK)]
        public IEnumerable<PostSleepingDTO> GetSleepings()
        {
            var result = sleepingsService.GetSleepings();

            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostSleepingDTO), StatusCodes.Status200OK)]
        public IActionResult GetSleeping([FromRoute] int id)
        {
            var result = sleepingsService.GetSleeping(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostSleeping([FromBody] PostSleepingDTO postSleepingDTO, int babyId)
        {
            var result = await sleepingsService.CreateSleeping(postSleepingDTO,babyId);

            if (result == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetSleeping", new { id = result.Id }, postSleepingDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSleeping([FromRoute] Sleeping editSleeping)
        {
            var result = await sleepingsService.UpdateSleeping(editSleeping);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Sleeping), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteSleeping([FromRoute] int id)
        {
            var result = await sleepingsService.DeleteSleeping(id);

            if (result == "Error")
            {
                return NotFound();
            }

            return Ok();
        }
    }
}