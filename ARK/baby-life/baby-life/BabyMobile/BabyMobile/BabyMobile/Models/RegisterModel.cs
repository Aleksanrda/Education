using System;
using System.Collections.Generic;
using System.Text;

namespace BabyMobile.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }

        public DateTime Year { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}
