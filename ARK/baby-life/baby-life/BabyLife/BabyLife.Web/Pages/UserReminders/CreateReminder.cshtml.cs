using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Reminders;
using BabyLife.Api.Reminders.DTO;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class CreateReminderModel : PageModel
    {
        private readonly IRemindersService remindersService;
        private readonly UserManager<User> userManager;

        [BindProperty]
        public PostReminderDTO NewReminder { get; set; }

        public CreateReminderModel(IRemindersService remindersService,
            UserManager<User> userManager)
        {
            this.remindersService = remindersService;
            this.userManager = userManager;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = userManager.GetUserId(User);

                var result = await remindersService.CreateReminder(NewReminder, userId);

                if (result != null)
                {
                    return RedirectToPage("/Babies/Reminders");
                }
                else
                {
                    return Page();
                }
            }
            return Page();
        }
    }
}