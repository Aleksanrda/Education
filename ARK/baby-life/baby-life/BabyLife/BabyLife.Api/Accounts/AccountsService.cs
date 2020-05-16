using BabyLife.Api.Accounts.AccountsModel;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Accounts
{
    public delegate void EventDelegate(string email);

    public class AccountsService : IAccountsService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUnitOfWork unitOfWork;

        public event EventDelegate MyEvent;

        public AccountsService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork;
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
                MyEvent?.Invoke(model.Email);
                await signInManager.SignInAsync(user, false);
                return user;
            }

            return null;
        }



        public async Task<LoginViewModel> Login(LoginViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            var result = await
                    signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                return model;
            }

            return null;
        }

        public async Task<User> LoginCarePerson(LoginCarePersonViewModel loginCarePerson)
        {
            var user = unitOfWork.Users.GetAll().FirstOrDefault(u => u.ShareCode == loginCarePerson.ShareCode);

            if (user != null)
            {
                await signInManager.SignInAsync(user, false, null);

                return user;
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
