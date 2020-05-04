using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Reminders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class DeleteRemindersModel : PageModel
    {
        private readonly IRemindersService remindersService;

        [BindProperty]
        public int Id { get; set; }

        public DeleteRemindersModel(IRemindersService remindersService)
        {
            this.remindersService = remindersService;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var result = await remindersService.DeleteReminder(Id);

            if (result == "Ok")
            {
                return RedirectToPage("/Babies/Reminders");
            }

            return Page();
        }
    }
}