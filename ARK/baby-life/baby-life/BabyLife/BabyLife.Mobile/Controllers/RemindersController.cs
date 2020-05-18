using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BabyLife.Api.Reminders;
using BabyLife.Api.Reminders.DTO;
using BabyLife.Core.Entities;
using BabyLife.Mobile.Models;
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

        [HttpGet("userReminders/{userId}")]
        [ProducesResponseType(typeof(PostReminderDTO[]), StatusCodes.Status200OK)]
        public IEnumerable<Reminder> GetUserReminders([FromRoute] string userId)
        {
            var result = remindersService.GetUserReminders(userId);

            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostReminderDTO), StatusCodes.Status200OK)]
        public IActionResult GetReminder([FromRoute] int id, string userId)
        {
            var result = remindersService.GetReminder(id, userId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("{userId}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostReminder([FromRoute] string userId, [FromBody] PostReminderDTO postReminderDTO)
        {
            var result = await remindersService.CreateReminder(postReminderDTO, userId);

            if (result == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetReminder", new { id = result.Id }, postReminderDTO);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> PutReminder([FromRoute] string userId, [FromBody] PutReminder putReminder)
        {
            var reminder = new Reminder()
            {
                Id = putReminder.Id,
                ReminderType = (ReminderType)Enum.Parse(typeof(ReminderType), putReminder.ReminderType),
                ReminderTime = putReminder.ReminderTime,
                Infa = putReminder.Infa,
            };

            var result = await remindersService.UpdateReminder(reminder, userId);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Reminder), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteReminder([FromRoute] int id)
        {
            var result = await remindersService.DeleteReminder(id);
            
            if (result == "Error")
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("send")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SendReminder()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("oleksandra.kryvko@nure.ua");
                mail.To.Add("kryvkoalexandra05@gmail.com");
                mail.Subject = "Hello World";
                mail.Body = "<h1>Hello</h1>";
                mail.IsBodyHtml = true;
               

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("oleksandra.kryvko@nure.ua", "23Dfnhei5");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

            return Ok();
        }
    }
}