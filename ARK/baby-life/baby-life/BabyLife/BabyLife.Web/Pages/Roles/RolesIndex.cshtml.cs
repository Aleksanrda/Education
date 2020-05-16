using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Roles;
using BabyLife.Api.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    [Authorize(Roles = "Careroles")]

    public class RolesIndexModel : PageModel
    {
        private readonly IRolesService rolesService;

        [BindProperty]
        public IList<IdentityRole> Roles { get; set; }

        public RolesIndexModel(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

        public void OnGet()
        {
            Roles = rolesService.GetRoles();
        }
    }
}