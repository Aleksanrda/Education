using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Api.Bathings;
using BabyLife.Api.Bathings.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class CreateBathingModel : PageModel
    {
        private readonly IBathingsService bathingsService;
        private readonly IBabiesService babiesService;

        [BindProperty]
        public PostBathingDTO NewBathing { get; set; }

        [BindProperty]
        public int BabyId { get; set; }

        public CreateBathingModel(IBathingsService bathingsService,
            IBabiesService babiesService)
        {
            this.bathingsService = bathingsService;
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
                var result = await bathingsService.CreateBathing(NewBathing, BabyId);

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