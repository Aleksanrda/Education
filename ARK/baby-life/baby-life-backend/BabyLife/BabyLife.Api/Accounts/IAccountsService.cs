using Babylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Api.Accounts
{
    public interface IAccountsService
    {
        public User GetByUseremailAndPassword(string useremail, string password);

        public User Create(User user, string password);
    }
}
