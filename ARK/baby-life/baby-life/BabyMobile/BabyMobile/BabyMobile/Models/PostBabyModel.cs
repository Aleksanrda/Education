using System;
using System.Collections.Generic;
using System.Text;

namespace BabyMobile.Models
{
    public class PostBabyModel
    {
        public string Name { get; set; }

        public string GenderType { get; set; }

        public string BloodType { get; set; }

        public string Allergies { get; set; }

        public string Notes { get; set; }

        public int Longtitude { get; set; }

        public int Latitude { get; set; }
    }
}
