using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace BabyLife.Core.Entities
{
    public class User : IdentityUser
    {
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; }

        public DateTime Birthdate { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public List<Baby> Babies { get; set; }
    }
}
