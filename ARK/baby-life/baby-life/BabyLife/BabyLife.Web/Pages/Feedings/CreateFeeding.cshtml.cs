using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Api.Feedings;
using BabyLife.Api.Feedings.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web.Pages.Feedings
{
    public class CreateFeedingModel : PageModel
    {
        private readonly IFeedingsService feedingsService;
        private readonly IBabiesService babiesService;

        [BindProperty]
        public PostFeedingsDTO NewFeeding { get; set; }

        [BindProperty]
        public int BabyId { get; set; }

        public CreateFeedingModel(IFeedingsService feedingsService,
            IBabiesService babiesService)
        {
            this.feedingsService = feedingsService;
            this.babiesService = babiesService;
        }

        public void OnGet(int id)
        {
            BabyId = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await feedingsService.CreateFeeding(NewFeeding, BabyId);

                if (result != null)
                {
                    return RedirectToPage("/Babies/Babies");
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