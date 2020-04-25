using System;
using System.Collections.Generic;
using System.Text;

namespace BabyLife.Api.Users.UsersModels
{
    public class CreateUserViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Year { get; set; }
    }
}
