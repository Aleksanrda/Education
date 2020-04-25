using BabyLife.Api.Users.UsersModels;
using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Users
{
    public interface IUsersService
    {
        IList<User> GetUsers();

        Task<User> GetUser(string id);

        Task<string> CreateUser(CreateUserViewModel model);

        Task<EditUserViewModel> EditUser(string id);

        Task<string> EditUser(EditUserViewModel model);

        Task<string> DeleteUser(string id);
    }
}
