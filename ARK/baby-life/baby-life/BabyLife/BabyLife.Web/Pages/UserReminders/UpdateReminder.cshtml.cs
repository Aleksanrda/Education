using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Reminders;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class UpdateReminderModel : PageModel
    {
        private readonly IRemindersService remindersService;
        private readonly UserManager<User> userManager;

        [BindProperty]
        public Reminder EditReminder { get; set; }

        public UpdateReminderModel(IRemindersService remindersService,
            UserManager<User> userManager)
        {
            this.remindersService = remindersService;
            this.userManager = userManager;
        }

        public IActionResult OnGet(int id)
        {
            var userId = userManager.GetUserId(User);
            var result = remindersService.GetReminder(id, userId);
            EditReminder = result;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = userManager.GetUserId(User);
                var result = await remindersService.UpdateReminder(EditReminder, userId);

                if (result != null)
                {
                    return RedirectToPage("/Babies/Reminders");
                }
            }

            return Page();
        }
    }
}