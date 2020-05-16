using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Sleepings;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class UpdateSleepingModel : PageModel
    {
        private readonly ISleepingsService sleepingsService;

        [BindProperty]
        public Sleeping EditSleeping { get; set; }

        public UpdateSleepingModel(ISleepingsService sleepingsService)
        {
            this.sleepingsService = sleepingsService;
        }

        public IActionResult OnGet(int id)
        {
            var sleeping = sleepingsService.GetSleeping(id);
            EditSleeping = sleeping;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await sleepingsService.UpdateSleeping(EditSleeping);

                if (result != null)
                {
                    return RedirectToPage("/Sleepings/IndexSleeping", new { id = EditSleeping.BabyId });
                }
            }

            return Page();
        }
    }
}