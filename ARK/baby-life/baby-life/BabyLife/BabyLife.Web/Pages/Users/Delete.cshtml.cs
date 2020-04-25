using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class DeleteModel : PageModel
    {
        private readonly IUsersService usersService;

        [BindProperty]
        public string Id { get; set; }

        public DeleteModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var result = await usersService.DeleteUser(Id);

            if (result == "Ok")
            {
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}