using System;
using System.Collections.Generic;
using System.Text;

namespace BabyLife.Core.Entities
{
    public class DiaperChange : Entity
    {
        public string Name { get; set; }

        public DateTime TimeDiaper { get; set; }

        public string Reason { get; set; }

        public int BabyId { get; set; }

        public Baby Baby { get; set; }
    }
}
