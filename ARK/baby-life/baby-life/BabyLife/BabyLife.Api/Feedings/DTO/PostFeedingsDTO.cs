using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BabyLife.Api.Feedings.DTO
{
    public class PostFeedingsDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int CountMilk { get; set; }

        [Required]
        public DateTime TimeMilk { get; set; }

        [Required]
        public Device Device { get; set; }

        [Required]
        public Baby Baby { get; set; }
    }
}
