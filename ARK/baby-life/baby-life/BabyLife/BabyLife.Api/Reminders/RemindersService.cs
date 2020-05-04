using BabyLife.Api.Reminders.DTO;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Reminders
{
    public class RemindersService : IRemindersService
    {
        private readonly IUnitOfWork unitOfWork;

        public RemindersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PostReminderDTO> GetReminders()
        {
            var result = unitOfWork.Reminders.GetAll().Select(x =>
           new PostReminderDTO()
           {
               ReminderType = x.ReminderType.ToString(),
               ReminderTime = x.ReminderTime,
               Infa = x.Infa,
           }).ToList();

            return result;
        }

        public IEnumerable<Reminder> GetUserReminders(string userId)
        {
            var reminders = unitOfWork.Reminders.GetAll();

            var day = DateTime.UtcNow;

            var reminderYear = day.Year;
            var userReminders = reminders.Where(reminder => reminder.UserId == userId
            && reminder.ReminderTime.Year >= day.Year
            && reminder.ReminderTime.Month >= day.Month
            && reminder.ReminderTime.Day >= day.Day);

            var userRemindersActual = userReminders.Where(t => t.ReminderTime.Day >= day.Day);

            return userRemindersActual;
        }

        public Reminder GetReminder(int id, string userId)
        {
            var result = unitOfWork.Reminders.GetAllLazyLoad(r => r.Id == id, r => r.User).AsNoTracking().First();

            var reminder = new Reminder()
            {
                Id = id,
                ReminderType = result.ReminderType,
                ReminderTime = result.ReminderTime,
                Infa = result.Infa,
                User = new User
                {
                    Id = userId
                },
                UserId = userId
            };

            return reminder;
        }

        public async Task<Reminder> CreateReminder(PostReminderDTO reminderDTO, string userId)
        {
            if (reminderDTO == null)
            {
                throw new ArgumentNullException(nameof(reminderDTO));
            }

            var users = unitOfWork.Users.GetAll();
            var user = users.FirstOrDefault(
                user => user.Id == userId);

            var reminder = new Reminder()
            {
                ReminderType = (ReminderType)Enum.Parse(typeof(ReminderType), reminderDTO.ReminderType),
                ReminderTime = reminderDTO.ReminderTime,
                Infa = reminderDTO.Infa
            };

            if (user != null)
            {
                reminder.UserId = user.Id;
                reminder.User = user;

                unitOfWork.Reminders.Create(reminder);
                await unitOfWork.SaveChangesAsync();

                return reminder;
            }

            return null;
        }

        public async Task<Reminder> UpdateReminder(Reminder updateReminder, string userId)
        {
            if (updateReminder == null)
            {
                throw new ArgumentNullException(nameof(updateReminder));
            }

            var users = unitOfWork.Users.GetAll();
            var user = users.FirstOrDefault(
                user => user.Email == user.Email);

            var reminders = unitOfWork.Reminders.GetAll();
            var reminder = reminders.FirstOrDefault(
                reminder => reminder.Id == updateReminder.Id);

            if (reminder != null)
            {
                reminder.ReminderType =  updateReminder.ReminderType;
                reminder.ReminderTime = updateReminder.ReminderTime;
                reminder.Infa = updateReminder.Infa;
            }

            if (user != null)
            {
                reminder.UserId = user.Id;
                reminder.User = user;

                unitOfWork.Reminders.Update(reminder);
                await unitOfWork.SaveChangesAsync();

                return reminder;
            }

            return null;
        }

        public async Task<string> DeleteReminder(int id)
        {
            var reminder = unitOfWork.Reminders.GetByID(id);

            if (reminder != null)
            {
                unitOfWork.Reminders.Delete(reminder);
                await unitOfWork.SaveChangesAsync();
                return "Ok";
            }

            return "Error";
        }
    }
}
