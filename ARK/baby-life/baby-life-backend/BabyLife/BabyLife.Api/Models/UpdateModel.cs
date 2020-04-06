using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Api.Models
{
    public class UpdateModel
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
