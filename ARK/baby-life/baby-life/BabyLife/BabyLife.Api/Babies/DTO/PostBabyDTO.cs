using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BabyLife.Api.Babies.DTO
{
    public class PostBabyDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string GenderType { get; set; }

        [Required]
        public string BloodType { get; set; }

        [Required]
        public string Allergies { get; set; }

        [Required]
        public string Notes { get; set; }

        //[Required]
        public int Longtitude { get; set; }

        //[Required]
        public int Latitude { get; set; }

        ////[Required]
        //public User User { get; set; }
    }
}
