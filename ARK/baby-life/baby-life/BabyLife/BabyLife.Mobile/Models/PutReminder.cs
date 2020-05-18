using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Mobile.Models
{
    public class PutReminder
    {
        public int Id { get; set; }

        public string ReminderType { get; set; }

        public DateTime ReminderTime { get; set; }

        public string Infa { get; set; }
    }
}
