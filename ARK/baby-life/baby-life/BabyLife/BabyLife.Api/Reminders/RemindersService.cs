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
               User = new User()
               {
                   Id = x.UserId
               }
           }).ToList();

            return result;
        }

        public PostReminderDTO GetReminder(int id)
        {
            var result = unitOfWork.Reminders.GetAllLazyLoad(r => r.Id == id, r => r.User).AsNoTracking().First();

            var reminder = new PostReminderDTO()
            {
                ReminderType = result.ReminderType.ToString(),
                ReminderTime = result.ReminderTime,
                Infa = result.Infa,
                User = new User()
                {
                    Id = result.UserId
                }
            };

            return reminder;
        }

        public async Task<Reminder> CreateReminder(PostReminderDTO reminderDTO)
        {
            if (reminderDTO == null)
            {
                throw new ArgumentNullException(nameof(reminderDTO));
            }

            var users = unitOfWork.Users.GetAll();
            var user = users.FirstOrDefault(
                user => user.Email == reminderDTO.User.Email);

            var reminder = new Reminder()
            {
                ReminderType = (ReminderType)Enum.Parse(typeof(ReminderType), reminderDTO.ReminderType),
                ReminderTime = reminderDTO.ReminderTime,
                Infa = reminderDTO.Infa
            };

            if (user != null)
            {
                reminder.UserId = reminder.User.Id;
                reminder.User = user;

                unitOfWork.Reminders.Create(reminder);
                await unitOfWork.SaveChangesAsync();

                return reminder;
            }

            return null;
        }

        public async Task<Reminder> UpdateReminder(int id, PostReminderDTO reminderDTO)
        {
            if (reminderDTO == null)
            {
                throw new ArgumentNullException(nameof(reminderDTO));
            }

            var users = unitOfWork.Users.GetAll();
            var user = users.FirstOrDefault(
                user => user.Email == reminderDTO.User.Email);

            var reminders = unitOfWork.Reminders.GetAll();
            var reminder = reminders.FirstOrDefault(
                reminder => reminder.Id == id);

            if (reminder != null)
            {
                reminder.ReminderType = (ReminderType)Enum.Parse(typeof(ReminderType), reminderDTO.ReminderType);
                reminder.ReminderTime = reminderDTO.ReminderTime;
                reminder.Infa = reminderDTO.Infa;
            }

            if (user != null)
            {
                reminder.UserId = reminderDTO.User.Id;
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
