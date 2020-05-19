using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Feedings;
using BabyLife.Api.Feedings.DTO;
using BabyLife.Core.Entities;
using BabyLife.Mobile.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabyLife.Mobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedingsController : ControllerBase
    {
        private readonly IFeedingsService feedingsService;

        public FeedingsController(IFeedingsService feedingsService)
        {
            this.feedingsService = feedingsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostFeedingsDTO[]), StatusCodes.Status200OK)]
        public IEnumerable<PostFeedingsDTO> GetFeedings()
        {
            var result = feedingsService.GetFeedings();

            return result;
        }

        [HttpGet("babyFeedings/{babyId}")]
        [ProducesResponseType(typeof(PostFeedingsDTO[]), StatusCodes.Status200OK)]
        public IEnumerable<Feeding> GetBabyFeedings([FromRoute] int babyId)
        {
            var result = feedingsService.GetBabyFeedings(babyId);

            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostFeedingsDTO), StatusCodes.Status200OK)]
        public IActionResult GetFeeding([FromRoute] int id)
        {
            var result = feedingsService.GetFeeding(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostFeeding([FromRoute] int id, [FromBody] PostFeedingsDTO feedingDTO)
        {
            var result = await feedingsService.CreateFeeding(feedingDTO, id);

            if (result == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetFeeding", new { id = result.Id }, feedingDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeeding([FromRoute] int id, [FromBody] PutFeeding putFeeding)
        {
            var feeding = new Feeding()
            {
                Id = putFeeding.Id,
                Name = putFeeding.Name,
                CountMilk = putFeeding.CountMilk,
                TimeMilk = putFeeding.TimeMilk,
                DeviceId = putFeeding.DeviceId,
                BabyId = id,
                Baby = new Baby()
                {
                    Id = id,
                }
            };

            var result = await feedingsService.UpdateFeeding(feeding);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Feeding), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteFeeding([FromRoute] int id)
        {
            var result = await feedingsService.DeleteFeeding(id);

            if (result == "Error")
            {
                return NotFound();
            }

            return Ok();
        }
    }
}