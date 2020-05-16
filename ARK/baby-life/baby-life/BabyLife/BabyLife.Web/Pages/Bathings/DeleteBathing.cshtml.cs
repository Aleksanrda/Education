using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Bathings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class DeleteBathingModel : PageModel
    {
        private readonly IBathingsService bathingsService;

        [BindProperty]
        public int Id { get; set; }

        public DeleteBathingModel(IBathingsService bathingsService)
        {
            this.bathingsService = bathingsService;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var result = await bathingsService.DeleteBathing(Id);

            if (result == "Ok")
            {
                return RedirectToPage("/Babies/Babies");
            }

            return Page();
        }
    }
}