using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creeperscare.API.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }
    }
}
