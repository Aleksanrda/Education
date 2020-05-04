using BabyLife.Api.Reminders.DTO;
using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Reminders
{
    public interface IRemindersService
    {
        IEnumerable<PostReminderDTO> GetReminders();

        IEnumerable<Reminder> GetUserReminders(string userId);

        Reminder GetReminder(int id, string userId);

        Task<Reminder> CreateReminder(PostReminderDTO reminderDTO, string userId);

        Task<Reminder> UpdateReminder(Reminder updateReminder, string userId);

        Task<string> DeleteReminder(int id);
    }
}
