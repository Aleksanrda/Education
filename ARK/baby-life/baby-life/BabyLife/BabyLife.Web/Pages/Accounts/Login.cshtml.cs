using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BabyLife.Api.Accounts;
using BabyLife.Api.Accounts.AccountsModel;
using BabyLife.Api.Roles;
using BabyLife.Api.Roles.RolesModel;
using BabyLife.Api.Users;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace BabyLife.Web
{
    [ValidateAntiForgeryToken]
    public class LoginModel : PageModel
    {
        private readonly IAccountsService accountsService;
        private readonly IStringLocalizer<LoginModel> localizer;
        private readonly UserManager<User> userManager;
        private readonly IUsersService usersService;
        private readonly IRolesService rolesService;

        [BindProperty]
        public LoginViewModel LoginUser { get; set; }

        public ChangeRoleViewModel RequestUser { get; set; }

        public LoginModel(IAccountsService accountsService,
            IStringLocalizer<LoginModel> localizer, IRolesService rolesService,
            UserManager<User> userManager, IUsersService usersService)
        {
            this.accountsService = accountsService;
            this.localizer = localizer;
            this.userManager = userManager;
            this.usersService = usersService;
            this.rolesService = rolesService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await accountsService.Login(LoginUser);

                if (result != null)
                {
                    var userId = userManager.GetUserId(User);
                    RequestUser = await rolesService.EditRole(userId);

                    if (RequestUser.UserRoles.Contains("Admin"))
                    {
                        return RedirectToPage("/Users/Index");
                    }
                    else if (RequestUser.UserRoles.Contains("Careroles"))
                    {
                        return RedirectToPage("/Roles/RolesIndex");
                    }
                    else
                    {
                        return RedirectToPage("/Babies/Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(String.Empty, localizer["InvalidLoginAttempt"]);
                    return Page();
                }
            }
            return Page();
        }
    }
}