using BabyLife.Api.Roles.RolesModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Roles
{
    public interface IRolesService
    {
        IList<IdentityRole> GetRoles();

        Task<string> CreateRole(string name);

        Task DeleteRole(string id);

        Task<ChangeRoleViewModel> EditRole(string userId);

        Task Edit(string userId, IList<string> roles);
    }
}
