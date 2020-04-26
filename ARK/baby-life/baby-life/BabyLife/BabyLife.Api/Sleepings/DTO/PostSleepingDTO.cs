using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabyLife.Api.Sleepings.DTO
{
    public class PostSleepingDTO
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Notes { get; set; }

        public int BabyId { get; set; }

        public Baby Baby { get; set; }
    }
}
