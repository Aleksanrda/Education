using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Accounts;
using BabyLife.Api.Accounts.AccountsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace BabyLife.Web
{
    public class LoginCarePersonModel : PageModel
    {
        private readonly IAccountsService accountsService;
        private readonly IStringLocalizer<LoginModel> localizer;

        [BindProperty]
        public LoginCarePersonViewModel LoginCareUser { get; set; }

        public LoginCarePersonModel(IAccountsService accountsService,
            IStringLocalizer<LoginModel> localizer)
        {
            this.accountsService = accountsService;
            this.localizer = localizer;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await accountsService.LoginCarePerson(LoginCareUser);

                if (result != null)
                {
                    return RedirectToPage("/Babies/Home");
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