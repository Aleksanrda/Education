using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Users;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    //[Authorize(Roles = "admin")]
    public class IndexModel : PageModel
    {
        private readonly IUsersService usersService;

        public List<User> Users { get; set; }

        public IndexModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public void OnGet()
        {
            Users = usersService.GetUsers().ToList();
        }
    }
}