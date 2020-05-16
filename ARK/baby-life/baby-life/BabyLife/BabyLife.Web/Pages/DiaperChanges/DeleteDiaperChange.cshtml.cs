using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.DiaperChanges;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class DeleteDiaperChangeModel : PageModel
    {
        private readonly IDiaperChangesService diaperChangesService;

        [BindProperty]
        public int Id { get; set; }

        public DeleteDiaperChangeModel(IDiaperChangesService diaperChangesService)
        {
            this.diaperChangesService = diaperChangesService;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var result = await diaperChangesService.DeleteDiaperChange(Id);

            if (result == "Ok")
            {
                return RedirectToPage("/Babies/Babies");
            }

            return Page();
        }
    }
}