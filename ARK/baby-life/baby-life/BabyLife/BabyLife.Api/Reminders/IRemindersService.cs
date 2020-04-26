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

        PostReminderDTO GetReminder(int id);

        Task<Reminder> CreateReminder(PostReminderDTO reminderDTO);

        Task<Reminder> UpdateReminder(int id, PostReminderDTO reminderDTO);

        Task<string> DeleteReminder(int id);
    }
}
