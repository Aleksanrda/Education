using System;
using System.Collections.Generic;
using System.Text;

namespace Babylife.Core.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public PersonType PersonType { get; set; }

        public int PhoneNumber { get; set; }

        public List<Baby> Babies { get; set; }
    }
}
