using System;
using System.Collections.Generic;
using System.Text;

namespace Babylife.Core.Entities
{
    public class Baby : Entity
    {
        public string Name { get; set; }

        public GenderType GenderType { get; set; }

        public string BloodType { get; set; }

        public string Allergies { get; set; }

        public string Notes { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
