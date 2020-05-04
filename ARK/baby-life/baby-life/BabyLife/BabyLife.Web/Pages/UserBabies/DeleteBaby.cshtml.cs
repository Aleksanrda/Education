using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class DeleteBabyModel : PageModel
    {
        private readonly IBabiesService babiesService;

        [BindProperty]
        public int Id { get; set; }

        public DeleteBabyModel(IBabiesService babiesService)
        {
            this.babiesService = babiesService;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var result = await babiesService.DeleteBaby(Id);

            if (result == "Ok")
            {
                return RedirectToPage("/Babies/Babies");
            }

            return Page();
        }
    }
}