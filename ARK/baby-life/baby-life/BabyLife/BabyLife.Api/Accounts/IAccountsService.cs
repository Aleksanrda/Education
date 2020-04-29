using BabyLife.Api.Accounts.AccountsModel;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Accounts
{
    public interface IAccountsService
    {
        Task<User> Register(RegisterViewModel model);

        Task<LoginViewModel> Login(LoginViewModel model);

        Task<User> LoginCarePerson(LoginCarePersonViewModel loginCarePerson);

        Task Logout();
    }
}
