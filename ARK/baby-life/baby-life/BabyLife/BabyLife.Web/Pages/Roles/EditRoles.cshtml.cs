using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Roles;
using BabyLife.Api.Roles.RolesModel;
using BabyLife.Api.Users;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class EditRolesModel : PageModel
    {
        private readonly IRolesService rolesService;

        [BindProperty]
        public ChangeRoleViewModel RequestUser { get; set; }

        public EditRolesModel(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            RequestUser = await rolesService.EditRole(id);
            
            if (RequestUser != null)
            {
                return Page();
            }

            return RedirectToPage("RolesIndex");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await rolesService.Edit(RequestUser.UserId, RequestUser.UserRoles);

            return RedirectToPage("RolesIndex");
        }
    }
}