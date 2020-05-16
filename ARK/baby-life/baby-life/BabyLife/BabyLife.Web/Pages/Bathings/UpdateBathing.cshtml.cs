using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Bathings;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class UpdateBathingModel : PageModel
    {
        private readonly IBathingsService bathingsService;

        [BindProperty]
        public Bathing EditBathing { get; set; }

        public UpdateBathingModel(IBathingsService bathingsService)
        {
            this.bathingsService = bathingsService;
        }

        public IActionResult OnGet(int id)
        {
            var bathing = bathingsService.GetBathing(id);
            EditBathing = bathing;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await bathingsService.UpdateBathing(EditBathing);

                if (result != null)
                {
                    return RedirectToPage("/Bathings/IndexBathing", new { id = EditBathing.BabyId });
                }
            }

            return Page();
        }
    }
}