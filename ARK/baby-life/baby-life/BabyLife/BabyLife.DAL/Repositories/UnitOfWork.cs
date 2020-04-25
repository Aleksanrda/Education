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
        private BabyLifeDbContext _babyLifeDbContext;
        private IRepository<User> _users;
        private IRepository<Baby> _babies;

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

        public async Task SaveChangesAsync()
        {
            await _babyLifeDbContext.SaveChangesAsync();
        }
    }
}
