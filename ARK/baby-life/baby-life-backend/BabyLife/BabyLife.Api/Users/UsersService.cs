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

        public User GetUserById(int id)
        {
            var user = unitOfWork.Users.GetByID(id);
            return user;
        }

        public void Update(User userParam, string password = null)
        {
            var user = unitOfWork.Users.GetByID(userParam.Id);

            if (user == null)
                throw new ArgumentException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Email) && userParam.Email != user.Email)
            {
                // throw error if the new username is already taken
                if (unitOfWork.Users.GetAll().Any(x => x.Email == userParam.Email))
                    throw new ArgumentException("Email " + userParam.Email + " is already taken");

                user.Email = userParam.Email;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.Name))
                user.Name = userParam.Name;

            if (!string.IsNullOrWhiteSpace(userParam.Email))
                user.Email = userParam.Email;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            unitOfWork.Users.Update(user);
            unitOfWork.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var user = unitOfWork.Users.GetByID(id);
            if (user != null)
            {
                unitOfWork.Users.Delete(user);
                unitOfWork.SaveChangesAsync();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}