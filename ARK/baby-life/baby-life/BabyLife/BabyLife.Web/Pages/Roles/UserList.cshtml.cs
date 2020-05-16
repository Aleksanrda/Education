using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Users;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    [Authorize(Roles = "Careroles")]

    public class UserListModel : PageModel
    {
        private readonly IUsersService usersService;

        public IList<User> Users { get; set; }

        public UserListModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult OnGet()
        {
            Users = usersService.GetUsers();

            return Page();
        }
    }
}