using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Api.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public int PhoneNumber { get; set; }
    }
}
