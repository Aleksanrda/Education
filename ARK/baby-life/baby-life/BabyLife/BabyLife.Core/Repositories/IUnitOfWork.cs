using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Core.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }

        IRepository<Baby> Babies { get; }

        IRepository<Reminder> Reminders { get; }

        IRepository<Sleeping> Sleepings { get; }

        IRepository<DiaperChange> DiaperChanges { get; }

        IRepository<Feeding> Feedings { get; }

        IRepository<Bathing> Bathings { get; }

        IRepository<Device> Devices { get; }

        Task SaveChangesAsync();

        void SaveChanges();
    }
}
