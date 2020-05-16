using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.DiaperChanges;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class UpdateDiaperChangeModel : PageModel
    {
        private readonly IDiaperChangesService diaperChangesService;

        [BindProperty]
        public DiaperChange EditDiaperChange { get; set; }

        public UpdateDiaperChangeModel(IDiaperChangesService diaperChangesService)
        {
            this.diaperChangesService = diaperChangesService;
        }

        public IActionResult OnGet(int id)
        {
            var diaperChange = diaperChangesService.GetDiaperChange(id);
            EditDiaperChange = diaperChange;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await diaperChangesService.UpdateDiaperChange(EditDiaperChange);

                if (result != null)
                {
                    return RedirectToPage("/DiaperChanges/IndexDiaperChange", new { id = EditDiaperChange.BabyId });
                }
            }

            return Page();
        }
    }
}