using System;
using System.Collections.Generic;
using System.Text;

namespace BabyMobile.Models
{
    public class Baby
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GenderType { get; set; }

        public string BloodType { get; set; }

        public string Allergies { get; set; }

        public string Notes { get; set; }

        public int Longtitude { get; set; }

        public int Latitude { get; set; }

        public string UserId { get; set; }
    }
}
