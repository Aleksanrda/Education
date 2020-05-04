using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Api.Babies.DTO;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class UpdateBabyModel : PageModel
    {
        private readonly IBabiesService babiesService;
        private readonly UserManager<User> userManager;

        [BindProperty]
        public Baby EditBaby { get; set; }

        public UpdateBabyModel(IBabiesService babiesService,
            UserManager<User> userManager)
        {
            this.babiesService = babiesService;
            this.userManager = userManager;
        }

        public IActionResult OnGet(int id)
        {
            var userId = userManager.GetUserId(User);
            var result = babiesService.GetBaby(id, userId);
            EditBaby = result;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = userManager.GetUserId(User);
                var result = await babiesService.UpdateBaby(EditBaby, userId);

                if (result != null)
                {
                    return RedirectToPage("/Babies/Babies");
                }
            }

            return Page();
        }
    }
}