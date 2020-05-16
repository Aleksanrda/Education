using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Feedings;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web.Pages.Feedings
{
    public class UpdateFeedingModel : PageModel
    {
        private readonly IFeedingsService feedingsService;

        [BindProperty]
        public Feeding EditFeeding { get; set; }

        public UpdateFeedingModel(IFeedingsService feedingsService)
        {
            this.feedingsService = feedingsService;
        }

        public IActionResult OnGet(int id)
        {
            var feeding = feedingsService.GetFeeding(id);
            EditFeeding = feeding;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await feedingsService.UpdateFeeding(EditFeeding);

                if (result != null)
                {
                    return RedirectToPage("/Feedings/IndexFeeding", new { id = EditFeeding.BabyId });
                }
            }

            return Page();
        }
    }
}