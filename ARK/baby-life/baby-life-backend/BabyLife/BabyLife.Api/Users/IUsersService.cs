using Babylife.Core.Entities;
using BabyLife.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Api.Users
{
    public interface IUsersService
    {
        CollectionResult<User> GetUsers(int skip, int take);

        public User GetUserById(int id);

        public void Update(User userParam, string password = null);

        public void Delete(int id);
    }
}
