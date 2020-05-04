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
    public class CreateBabyModel : PageModel
    {
        private readonly IBabiesService babiesService;
        private readonly UserManager<User> userManager;

        [BindProperty]
        public PostBabyDTO NewBaby { get; set; }

        public CreateBabyModel(IBabiesService babiesService,
            UserManager<User> userManager)
        {
            this.babiesService = babiesService;
            this.userManager = userManager;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = userManager.GetUserId(User);

                var result = await babiesService.CreateBaby(NewBaby, userId);

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