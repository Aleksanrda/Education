using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using BabyLife.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace BabyLife.Web
{
    public class BabyHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceProvider _provider;

        public BabyHostedService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SendReminder, null, 0, 3600000);
            return Task.CompletedTask;
        }

        void SendReminder(object state)
        {
            using (var scope = _provider.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var reminders = unitOfWork.Reminders.GetAll().Select(x =>
           new Reminder()
           {
               ReminderType = x.ReminderType,
               ReminderTime = x.ReminderTime,
               Infa = x.Infa,
               User = new User()
               {
                   Id = x.UserId
               }
           }).ToList();

                DateTime datetime = DateTime.UtcNow;

                for (int i = 0; i < reminders.Count; i++)
                {
                    if (reminders[i].ReminderTime.Day == datetime.Day
                        && reminders[i].ReminderTime.Month == datetime.Month
                        && reminders[i].ReminderTime.Year == datetime.Year
                        && reminders[i].ReminderTime.Hour < datetime.Hour)
                    {
                        var user = unitOfWork.Users.GetByID(reminders[i].User.Id);

                        using (MailMessage mail = new MailMessage())
                        {
                            mail.From = new MailAddress("oleksandra.kryvko@nure.ua");
                            mail.To.Add(user.Email);
                            mail.Subject = reminders[i].ReminderType.ToString();
                            mail.Body = reminders[i].Infa;
                            mail.IsBodyHtml = true;

                            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                            {
                                smtp.Credentials = new NetworkCredential("oleksandra.kryvko@nure.ua", "23Dfnhei5");
                                smtp.EnableSsl = true;
                                smtp.Send(mail);
                            }
                        }

                        unitOfWork.Reminders.Delete(reminders[i]);
                    }
                }
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //New Timer does not have a stop. 
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
