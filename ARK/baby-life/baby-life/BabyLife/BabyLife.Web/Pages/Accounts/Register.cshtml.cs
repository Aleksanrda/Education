using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BabyLife.Api.Accounts;
using BabyLife.Api.Accounts.AccountsModel;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountsService accountsService;

        [BindProperty]
        public RegisterViewModel Model { get; set; }

        public RegisterModel(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await accountsService.Register(Model);

                if (result != null)
                {
                    return RedirectToPage("/Babies/Home");
                }
                else
                {
                    ModelState.AddModelError("Login", "User already exsists with this login");
                }
            }

            return Page();
        }
    }
}