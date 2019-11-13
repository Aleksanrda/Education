using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;

namespace Creeperscare.Entities
{
    public class User : IdentityUser
    {
        public string Role { get; set; }

        public int? SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }

        public List<Device> Devices { get; set; }

        public User()
        {
            Devices = new List<Device>();
        }
    }
}
