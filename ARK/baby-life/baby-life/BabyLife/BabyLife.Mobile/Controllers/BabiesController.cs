using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Api.Babies.DTO;
using BabyLife.Core.Entities;
using BabyLife.Mobile.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabyLife.Mobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabiesController : ControllerBase
    {
        private readonly IBabiesService babiesService;

        public BabiesController(IBabiesService babiesService)
        {
            this.babiesService = babiesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostBabyDTO[]), StatusCodes.Status200OK)]
        public IEnumerable<Baby> GetBabies()
        {
            var result = babiesService.GetBabies();

            return result;
        }

        [HttpGet("userBabies/{userId}")]
        [ProducesResponseType(typeof(PostBabyDTO[]), StatusCodes.Status200OK)]
        public IEnumerable<Baby> GetUserBabies([FromRoute] string userId)
        {
            var result = babiesService.GetUserBabies(userId);

            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostBabyDTO), StatusCodes.Status200OK)]
        public IActionResult GetBaby([FromRoute] int id, string userId)
        {
            var result = babiesService.GetBaby(id, userId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("{userId}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostBaby([FromRoute] string userId, [FromBody] PostBabyDTO baby)
        {
            //var postBabyDTO = new PostBabyDTO()
            //{
            //    Name = baby.Name,
            //    GenderType = baby.Name,
            //    BloodType = baby.BloodType,
            //    Allergies = baby.Allergies,
            //    Notes = baby.Notes
            //};

            var result = await babiesService.CreateBaby(baby, userId);

            if (result == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetBaby", new { id = result.Id }, baby);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> PutBaby([FromRoute] string userId, [FromBody] PutBaby baby)
        {
            var putBaby = new Baby()
            {
                Id = baby.Id,
                Name = baby.Name,
                GenderType = (GenderType)Enum.Parse(typeof(GenderType), baby.GenderType),
                BloodType = baby.BloodType,
                Allergies = baby.Allergies,
                Notes = baby.Notes
            };

            var result = await babiesService.UpdateBaby(putBaby, userId);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Baby), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBaby([FromRoute] int id)
        {
            var result = await babiesService.DeleteBaby(id);

            if (result == "Error")
            {
                return NotFound();
            }

            return Ok();
        }
    }
}