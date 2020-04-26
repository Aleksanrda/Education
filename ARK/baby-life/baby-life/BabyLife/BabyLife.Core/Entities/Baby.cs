using System;
using System.Collections.Generic;
using System.Text;

namespace BabyLife.Core.Entities
{
    public class Baby : Entity
    {
        public string Name { get; set; }

        public GenderType GenderType { get; set; }

        public string BloodType { get; set; }

        public string Allergies { get; set; }

        public string Notes { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public List<Bathing> Bathings { get; set; }

        public List<DiaperChange> DiaperChanges { get; set; }

        public List<Sleeping> Sleepings { get; set; }

        public List<Feeding> Feedings { get; set; }
    }
}
