using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Reminders;
using BabyLife.Api.Reminders.DTO;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabyLife.Mobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly IRemindersService remindersService;

        public RemindersController(IRemindersService remindersService)
        {
            this.remindersService = remindersService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostReminderDTO[]), StatusCodes.Status200OK)]
        public IEnumerable<PostReminderDTO> GetReminders()
        {
            var result = remindersService.GetReminders();

            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostReminderDTO), StatusCodes.Status200OK)]
        public IActionResult GetReminder([FromRoute] int id)
        {
            var result = remindersService.GetReminder(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostReminder([FromBody] PostReminderDTO postReminderDTO)
        {
            var result = await remindersService.CreateReminder(postReminderDTO);

            if (result == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetReminder", new { id = result.Id }, postReminderDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaby([FromRoute] int id, [FromBody] PostReminderDTO postReminderDTO)
        {
            var result = await remindersService.UpdateReminder(id, postReminderDTO);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Reminder), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBaby([FromRoute] int id)
        {
            var result = await remindersService.DeleteReminder(id);

            if (result == "Error")
            {
                return NotFound();
            }

            return Ok();
        }
    }
}