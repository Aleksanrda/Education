using BabyLife.Api.Accounts.AccountsModel;
using BabyLife.Core.Entities;
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

        Task Logout();
    }
}
