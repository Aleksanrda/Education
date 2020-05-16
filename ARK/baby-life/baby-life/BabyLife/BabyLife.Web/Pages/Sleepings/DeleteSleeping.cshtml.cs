using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Sleepings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class DeleteSleepingModel : PageModel
    {
        private readonly ISleepingsService sleepingsService;

        [BindProperty]
        public int Id { get; set; }

        public DeleteSleepingModel(ISleepingsService sleepingsService)
        {
            this.sleepingsService = sleepingsService;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var result = await sleepingsService.DeleteSleeping(Id);

            if (result == "Ok")
            {
                return RedirectToPage("/Babies/Babies");
            }

            return Page();
        }
    }
}