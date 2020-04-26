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
        public IEnumerable<PostBabyDTO> GetBabies()
        {
            var result = babiesService.GetBabies();

            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostBabyDTO), StatusCodes.Status200OK)]
        public IActionResult GetBaby([FromRoute] int id)
        {
            var result = babiesService.GetBaby(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostBaby([FromBody] PostBabyDTO postBabyDTO)
        {
            var result = await babiesService.CreateBaby(postBabyDTO);

            if (result == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetBaby", new { id = result.Id }, postBabyDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaby([FromRoute] int id, [FromBody] PostBabyDTO postBabyDTO)
        {
            var result = await babiesService.UpdateBaby(id, postBabyDTO);

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