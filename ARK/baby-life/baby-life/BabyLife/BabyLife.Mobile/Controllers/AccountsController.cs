using BabyLife.Api.Accounts.AccountsModel;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BabyLife.Mobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController
    {
        private readonly UserManager<User> userManager;

        public AccountsController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<string> Register(RegisterViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var user = new User() { UserName = model.Email, Email = model.Email, Birthdate = model.Year };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return "Error";
            }

            return "Ok";
        }
    }
}
