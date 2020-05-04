using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BabyLife.Api.Reminders.DTO
{
    public class PostReminderDTO
    {
        [Required]
        public string ReminderType { get; set; }

        [Required]
        public DateTime ReminderTime { get; set; }

        [Required]
        public string Infa { get; set; }

        //[Required]
        //public User User { get; set; }
    }
}
