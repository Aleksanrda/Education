using System;
using System.Collections.Generic;
using System.Text;

namespace BabyLife.Core.Entities
{
    public class Reminder : Entity
    {
        public ReminderType ReminderType { get; set; }

        public DateTime ReminderTime { get; set; }

        public string Infa { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
