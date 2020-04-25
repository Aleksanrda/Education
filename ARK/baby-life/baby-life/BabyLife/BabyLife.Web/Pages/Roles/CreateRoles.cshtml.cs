using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class CreateRolesModel : PageModel
    {
        private readonly IRolesService rolesService;

        [BindProperty]
        public string Name { get; set; }

        public CreateRolesModel(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

        public void OnGet()
        {
            
        }

        public async Task<ActionResult> OnPost()
        {
            var result = await rolesService.CreateRole(Name);

            if (result == "Ok")
            {
                return RedirectToPage("RolesIndex");
            }

            return Page();
        }
    }
}