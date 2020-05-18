using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Mobile.Models
{
    public class PutBaby
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GenderType { get; set; }

        public string BloodType { get; set; }

        public string Allergies { get; set; }

        public string Notes { get; set; }

        public int Longtitude { get; set; }

        public int Latitude { get; set; }
    }
}
