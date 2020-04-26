using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BabyLife.Api.DiaperChanges.DTO
{
    public class PostDiaperChanges
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime TimeDiaper { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public int BabyId { get; set; }

        [Required]
        public Baby Baby { get; set; }
    }
}
