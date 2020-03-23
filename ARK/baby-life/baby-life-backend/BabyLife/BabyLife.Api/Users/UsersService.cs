using Babylife.Core.Entities;
using Babylife.Core.Repositories;
using BabyLife.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Api.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork unitOfWork;

        public UsersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CollectionResult<User> GetUsers(int skip, int take)
        {
            var amount = unitOfWork.Users.GetAll().Count();
            var users = unitOfWork.Users.GetAll().Skip(skip).Take(take).ToList();
            return new CollectionResult<User>(users, amount);
        }
    }
}
