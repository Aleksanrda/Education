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

        Task SaveChangesAsync();
    }
}
