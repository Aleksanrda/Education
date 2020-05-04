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
    public class RemindersModel : PageModel
    {
        private readonly IRemindersService remindersService;
        private readonly UserManager<User> userManager;

        public List<Reminder> Reminders { get; set; }

        public RemindersModel(IRemindersService remindersService,
             UserManager<User> userManager)
        {
            this.remindersService = remindersService;
            this.userManager = userManager;
        }

        public void OnGet()
        {
            var userId = userManager.GetUserId(User);

            Reminders = remindersService.GetUserReminders(userId).ToList();
        }
    }
}