using BabyLife.Api.Accounts.AccountsModel;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Accounts
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountsService(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<User> Register(RegisterViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            User user = new User { Email = model.Email, UserName = model.Email, Birthdate = model.Year };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return user;
            }

            return user;
        }

        public async Task<LoginViewModel> Login(LoginViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            var result = await
                    signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result != null)
            {
                return model;
            }

            return null;
        }

        public async Task Logout()
        {
            // удаляем аутентификационные куки
            await signInManager.SignOutAsync();
        }
    }
}
