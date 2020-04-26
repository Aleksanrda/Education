﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BabyLife.Core.Entities
{
    public class Sleeping : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public string Notes { get; set; }

        [Required]
        public int BabyId { get; set; }

        [Required]
        public Baby Baby { get; set; } 
    }
}
