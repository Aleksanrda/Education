using Babylife.Core.Entities;
using Babylife.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private BabyLifeDbContext _babyLifeDbContext;
        private IRepositoryBase<User> _users;
        private IRepositoryBase<Baby> _babies;

        public UnitOfWork(BabyLifeDbContext babyLifeDbContext)
        {
            _babyLifeDbContext = babyLifeDbContext;
        }

        public IRepositoryBase<User> Users
        {
            get
            {
                return _users ??
                    (_users = new RepositoryBase<User>(_babyLifeDbContext));
            }
        }

        public IRepositoryBase<Baby> Babies
        {
            get
            {
                return _babies ??
                    (_babies = new RepositoryBase<Baby>(_babyLifeDbContext));
            }
        }

        public async Task SaveChangesAsync()
        {
            await _babyLifeDbContext.SaveChangesAsync();
        }
    }
}
