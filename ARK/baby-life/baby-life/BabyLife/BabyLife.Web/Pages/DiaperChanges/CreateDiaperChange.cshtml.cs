using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Api.DiaperChanges;
using BabyLife.Api.DiaperChanges.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class CreateDiaperChangeModel : PageModel
    {
        private readonly IDiaperChangesService diaperChangesService;
        private readonly IBabiesService babiesService;

        [BindProperty]
        public PostDiaperChanges NewDiaperChange { get; set; }

        [BindProperty]
        public int BabyId { get; set; }

        public CreateDiaperChangeModel(IDiaperChangesService diaperChangesService,
            IBabiesService babiesService)
        {
            this.diaperChangesService = diaperChangesService;
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
                var result = await diaperChangesService.CreateDiaperChange(NewDiaperChange, BabyId);

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