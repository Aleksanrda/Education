using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BabyLifeDbContext _babyLifeDbContext;
        private IRepository<User> _users;
        private IRepository<Baby> _babies;
        private IRepository<Reminder> _reminders;
        private IRepository<Sleeping> _sleepings;
        private IRepository<Feeding> _feedings;
        private IRepository<Bathing> _bathings;
        private IRepository<DiaperChange> _diaperChanges;
        private IRepository<Device> _devices;

        public UnitOfWork(BabyLifeDbContext babyLifeDbContext)
        {
            _babyLifeDbContext = babyLifeDbContext;
        }

        public IRepository<User> Users
        {
            get
            {
                return _users ??
                    (_users = new Repository<User>(_babyLifeDbContext));
            }
        }

        public IRepository<Baby> Babies
        {
            get
            {
                return _babies ??
                    (_babies = new Repository<Baby>(_babyLifeDbContext));
            }
        }

        public IRepository<Reminder> Reminders
        {
            get
            {
                return _reminders ??
                    (_reminders = new Repository<Reminder>(_babyLifeDbContext));
            }
        }

        public IRepository<Sleeping> Sleepings
        {
            get
            {
                return _sleepings ??
                    (_sleepings = new Repository<Sleeping>(_babyLifeDbContext));
            }
        }

        public IRepository<Bathing> Bathings
        {
            get
            {
                return _bathings ??
                    (_bathings = new Repository<Bathing>(_babyLifeDbContext));
            }
        }

        public IRepository<Feeding> Feedings
        {
            get
            {
                return _feedings ??
                    (_feedings = new Repository<Feeding>(_babyLifeDbContext));
            }
        }

        public IRepository<DiaperChange> DiaperChanges
        {
            get
            {
                return _diaperChanges ??
                    (_diaperChanges = new Repository<DiaperChange>(_babyLifeDbContext));
            }
        }

        public IRepository<Device> Devices
        {
            get
            {
                return _devices ??
                    (_devices = new Repository<Device>(_babyLifeDbContext));
            }
        }

        public async Task SaveChangesAsync()
        {
            await _babyLifeDbContext.SaveChangesAsync();
        }
    }
}
