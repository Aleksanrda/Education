using BabyLife.Api.Users.UsersModels;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork unitOfWork;
        UserManager<User> userManager;

        public UsersService(IUnitOfWork unitOfWork,
            UserManager<User> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public IList<User> GetUsers()
        {
            var result = userManager.Users.ToList();

            return result;
        }

        public async Task<User> GetUser(string id)
        {
            var result = await userManager.FindByIdAsync(id);
            return result;
        }

        public async Task<string> CreateUser(CreateUserViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            User user = new User { Email = model.Email, UserName = model.Email, Birthdate = model.Year };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return "Ok";
            }
            else
            {
                return result.Errors.ToList().ToString();
            }
        }

        public async Task<EditUserViewModel> EditUser(string id)
        {
            User user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            EditUserViewModel model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Year = user.Birthdate,
                ShareCode = user.ShareCode
            };

            return model;
        }

        public async Task<string> EditUser(EditUserViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            User user = await userManager.FindByIdAsync(model.Id);

            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                user.Birthdate = model.Year;
                user.ShareCode = model.ShareCode;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return "Ok";
                }
                else
                {
                    result.Errors.ToList().ToString();
                }
            }

            return "Error";
        }

        public async Task<string> DeleteUser(string id)
        {
            User user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                
                if (result.Succeeded)
                {
                    return "Ok";
                }
                else
                {
                    return result.Errors.ToList().ToString();
                }
            }

            return "Error";
        }
    }
}
