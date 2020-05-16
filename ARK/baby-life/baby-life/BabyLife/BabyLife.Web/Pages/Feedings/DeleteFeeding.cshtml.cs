using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Devices;
using BabyLife.Api.Feedings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web.Pages.Feedings
{
    public class DeleteFeedingModel : PageModel
    {
        private readonly IFeedingsService feedingsService;

        [BindProperty]
        public int Id { get; set; }

        public DeleteFeedingModel(IFeedingsService feedingsService)
        {
            this.feedingsService = feedingsService;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var result = await feedingsService.DeleteFeeding(Id);

            if (result == "Ok")
            {
                return RedirectToPage("/Babies/Babies");
            }

            return Page();
        }
    }
}