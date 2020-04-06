using System;
using System.Collections.Generic;
using System.Text;

namespace Babylife.Core.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public Role PersonType { get; set; }

        public int PhoneNumber { get; set; }

        public string Token { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public List<Baby> Babies { get; set; }
    }
}
