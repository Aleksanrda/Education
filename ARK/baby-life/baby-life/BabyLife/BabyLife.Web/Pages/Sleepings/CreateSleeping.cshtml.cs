using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Api.Sleepings;
using BabyLife.Api.Sleepings.DTO;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class CreateSleepingModel : PageModel
    {
        private readonly ISleepingsService sleepingsService;
        private readonly IBabiesService babiesService;

        [BindProperty]
        public PostSleepingDTO NewSleeping { get; set; }

        [BindProperty]
        public int BabyId { get; set; }

        public CreateSleepingModel(ISleepingsService sleepingsService,
            IBabiesService babiesService)
        {
            this.sleepingsService = sleepingsService;
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
                var result = await sleepingsService.CreateSleeping(NewSleeping, BabyId);

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