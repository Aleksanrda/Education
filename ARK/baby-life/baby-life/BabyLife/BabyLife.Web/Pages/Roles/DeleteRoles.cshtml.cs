using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    [Authorize(Roles = "Careroles")]

    public class DeleteRolesModel : PageModel
    {
        private readonly IRolesService rolesService;

        [BindProperty]
        public string Id { get; set; }

        public DeleteRolesModel(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

        public async Task<IActionResult> OnPost()
        {
            await rolesService.DeleteRole(Id);

            return RedirectToPage("RolesIndex");
        }
    }
}