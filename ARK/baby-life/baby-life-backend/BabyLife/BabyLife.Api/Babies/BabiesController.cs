using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Babylife.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabyLife.Api.Babies
{
    [ApiController]
    [Route("api/[controller]")]

    public class BabiesController : ControllerBase
    {
        private readonly IBabiesService babiesService;

        public BabiesController(IBabiesService babiesService)
        {
            this.babiesService = babiesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Baby[]), StatusCodes.Status200OK)]
        public IActionResult GetBabies(int skip = 0, int take = 10)
        {
            var babiesResult = babiesService.GetBabies(skip, take);

            var response = new
            {
                items = babiesResult.Items
                .Select(b => new
                {
                    id = b.Id,
                    name = b.Name,
                    genderType = b.GenderType,
                    bloodType = b.BloodType,
                    allergies = b.Allergies,
                    notes = b.Notes,
                }),
                totalAmount = babiesResult.TotalAmount,
            };

            return Ok(response);
        }
    }
}