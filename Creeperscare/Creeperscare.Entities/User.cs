using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creeperscare.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }

        public List<Device> Devices { get; set; }

        public User()
        {
            Devices = new List<Device>();
        }
    }
}
