using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BabyLife.Core.Entities
{
    public class Sleeping : Entity
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Notes { get; set; }

        public int BabyId { get; set; }

        public Baby Baby { get; set; } 
    }
}
