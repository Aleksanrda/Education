using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Accounts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class LogoutModel : PageModel
    {
        private readonly IAccountsService accountsService;

        public LogoutModel(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            if (User.Identity.IsAuthenticated)
            {
                await accountsService.Logout();

                return RedirectToPage("/Accounts/Login");
            }

            string url = Url.Page("Login");

            return LocalRedirect(url);

        }
    }
}