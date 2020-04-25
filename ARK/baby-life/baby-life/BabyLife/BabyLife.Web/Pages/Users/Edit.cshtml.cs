using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Users;
using BabyLife.Api.Users.UsersModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class EditModel : PageModel
    {
        private readonly IUsersService usersService;

        [BindProperty]
        public EditUserViewModel EditUser { get; set; }

        public EditModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var result = await usersService.EditUser(id);
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
                    return RedirectToPage("Index");
                }
            }

            return Page();
        }
    }
}