using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace BabyLife.Core.Entities
{
    public class User : IdentityUser
    {
        public DateTime Birthdate { get; set; }

        public int ShareCode { get; set; }

        public List<Baby> Babies { get; set; }

        public List<Reminder> Reminders { get; set; }
    }
}
