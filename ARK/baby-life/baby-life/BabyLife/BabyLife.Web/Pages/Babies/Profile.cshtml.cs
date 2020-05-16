using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Users;
using BabyLife.Api.Users.UsersModels;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class ProfileModel : PageModel
    {
        private readonly IUsersService usersService;
        private readonly UserManager<User> userManager;

        [BindProperty]
        public EditUserViewModel EditUser { get; set; }

        public ProfileModel(IUsersService usersService,
            UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = userManager.GetUserId(User);
            var result = await usersService.EditUser(userId);
            EditUser = result;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await usersService.EditUser(EditUser);

                if (result == "Ok")
                {
                    return RedirectToPage("/Babies/Profile");
                }
            }

            return Page();
        }
    }
}