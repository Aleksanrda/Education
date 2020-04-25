using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Users;
using BabyLife.Api.Users.UsersModels;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class CreateModel : PageModel
    {
        private readonly IUsersService usersService;

        [BindProperty]
        public CreateUserViewModel NewUser { get; set; }

        public CreateModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await usersService.CreateUser(NewUser);
                if (result == "Ok")
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    return Page();
                }
            }
            return Page();
        }
    }
}