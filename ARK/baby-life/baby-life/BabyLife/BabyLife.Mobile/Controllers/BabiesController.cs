using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Api.Babies.DTO;
using BabyLife.Core.Entities;
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

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostBaby([FromBody] PostBabyDTO postBabyDTO, string userId)
        {
            var result = await babiesService.CreateBaby(postBabyDTO, userId);

            if (result == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetBaby", new { id = result.Id }, postBabyDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaby([FromBody] Baby baby, string userId)
        {
            var result = await babiesService.UpdateBaby(baby, userId);

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

            if(result == "Error")
            {
                return NotFound();
            }

            return Ok();
        }
    }
}