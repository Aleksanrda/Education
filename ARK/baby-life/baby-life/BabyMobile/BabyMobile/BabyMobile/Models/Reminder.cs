using System;
using System.Collections.Generic;
using System.Text;

namespace BabyMobile.Models
{
    public class Reminder
    {
        public int Id { get; set; }

        public string ReminderType { get; set; }

        public DateTime ReminderTime { get; set; }

        public string Infa { get; set; }
    }
}