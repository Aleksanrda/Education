using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BabyLife.Api.Accounts;
using BabyLife.Api.Accounts.AccountsModel;
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
        private readonly IStringLocalizer<SharedResource> sharedLocalizer;

        [BindProperty]
        public LoginViewModel LoginUser { get; set; }

        public LoginModel(IAccountsService accountsService,
            IStringLocalizer<LoginModel> localizer)
        {
            this.accountsService = accountsService;
            this.localizer = localizer;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await accountsService.Login(LoginUser);

                if (result != null)
                {
                    return RedirectToPage("/Index");
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