using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public IActionResult GetReminder([FromRoute] int id, string userId)
        {
            var result = remindersService.GetReminder(id, userId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostReminder([FromBody] PostReminderDTO postReminderDTO, string userId)
        {
            var result = await remindersService.CreateReminder(postReminderDTO, userId);

            if (result == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetReminder", new { id = result.Id }, postReminderDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaby([FromRoute] int id, [FromBody] Reminder postReminder, string userId)
        {
            var result = await remindersService.UpdateReminder(postReminder, userId);

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