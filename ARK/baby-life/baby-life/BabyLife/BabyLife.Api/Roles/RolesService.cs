using BabyLife.Api.Roles.RolesModel;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Roles
{
    public class RolesService : IRolesService
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<User> userManager;

        public RolesService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IList<IdentityRole> GetRoles()
        {
            var result = roleManager.Roles.ToList();

            return result;
        }

        public async Task<string> CreateRole(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
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

        public async Task DeleteRole(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
            }
        }

        public async Task<ChangeRoleViewModel> EditRole(string userId)
        {
            User user = await userManager.FindByIdAsync(userId);

            ChangeRoleViewModel model = new ChangeRoleViewModel();

            if (user != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var allRoles = roleManager.Roles.ToList();

                model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };

                return model;
            }

            return model;
        }

        public async Task Edit(string userId, IList<string> roles)
        {
            User user = await userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var allRoles = roleManager.Roles.ToList();

                var addedRoles = roles.Except(userRoles);

                var removedRoles = userRoles.Except(roles);

                await userManager.AddToRolesAsync(user, addedRoles);

                await userManager.RemoveFromRolesAsync(user, removedRoles);
            }
        }
    }
}
