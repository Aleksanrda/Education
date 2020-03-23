using Babylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Babylife.Core.Repositories
{
    public interface IUnitOfWork
    {
        IRepositoryBase<User> Users { get; }

        IRepositoryBase<Baby> Babies { get; }

        Task SaveChangesAsync();
    }
}