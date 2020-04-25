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

namespace BabyLife.Web
{
    [ValidateAntiForgeryToken]
    public class LoginModel : PageModel
    {
        private readonly IAccountsService accountsService;
       

        [BindProperty]
        public LoginViewModel LoginUser { get; set; }

        public LoginModel(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
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
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return Page();
        }
    }
}