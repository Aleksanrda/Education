using System;
using System.Collections.Generic;
using System.Text;

namespace BabyMobile.Models
{
    public class Profile
    {
        public string UserId { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public int ShareCode { get; set; }
    }
}
