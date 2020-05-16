using BabyLife.Api.Babies.DTO;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Babies
{
    public class BabiesService : IBabiesService
    {
        private readonly IUnitOfWork unitOfWork;

        public BabiesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Baby> GetBabies()
        {
            var result = unitOfWork.Babies.GetAll().Select(x =>
           new Baby()
           {
               Name = x.Name,
               GenderType = x.GenderType,
               BloodType = x.BloodType,
               Allergies = x.Allergies,
               Notes = x.Notes,
               User = new User()
               {
                   Id = x.UserId
               }
           }).ToList();

            return result;
        }

        public IEnumerable<Baby> GetUserBabies(string userId)
        {
            var babies = unitOfWork.Babies.GetAll();

            var userBabies = babies.Where(baby => baby.UserId == userId);

            return userBabies;
        }

        public Baby GetBaby(int id)
        {
            var baby = unitOfWork.Babies.GetByID(id);

            return baby;
        }


        public Baby GetBaby(int id, string userId)
        {
            var result = unitOfWork.Babies.GetByID(id);

            var baby = new Baby()
            {
                Id = id,
                Name = result.Name,
                GenderType = result.GenderType,
                BloodType = result.BloodType,
                Allergies = result.Allergies,
                Notes = result.Notes,
                User = new User
                {
                    Id = userId
                },
                UserId = userId
            };

            return baby;
        }

        public async Task<Baby> CreateBaby(PostBabyDTO baby, string userId)
        {
            if (baby == null)
            {
                throw new ArgumentNullException(nameof(baby));
            }

            var users = unitOfWork.Users.GetAll();
            var user = users.FirstOrDefault(
                user => user.Id == userId);

            var newBaby = new Baby()
            {
                Name = baby.Name,
                BloodType = baby.BloodType,
                Allergies = baby.Allergies,
                Notes = baby.Notes,
                GenderType = (GenderType)Enum.Parse(typeof(GenderType), baby.GenderType)
            };

            if (user != null)
            {
                newBaby.UserId = user.Id;
                newBaby.User = user;

                unitOfWork.Babies.Create(newBaby);
                await unitOfWork.SaveChangesAsync();

                return newBaby;
            }

            return null;
        }

        public async Task<Baby> UpdateBaby(Baby baby, string userId)
        {
            if (baby == null)
            {
                throw new ArgumentNullException(nameof(baby));
            }

            var users = unitOfWork.Users.GetAll();
            var user = users.FirstOrDefault(
                user => user.Id == userId);

            var babies = unitOfWork.Babies.GetAll();
            var editBaby = babies.FirstOrDefault(
                currentBaby => currentBaby.Id == baby.Id);

            if (editBaby != null)
            {
                editBaby.Name = baby.Name;
                editBaby.BloodType = baby.BloodType;
                editBaby.Allergies = baby.Allergies;
                editBaby.Notes = baby.Notes;
                editBaby.GenderType = baby.GenderType;
            }

            if (user != null)
            {
                editBaby.UserId = user.Id;
                editBaby.User = user;

                unitOfWork.Babies.Update(editBaby);
                await unitOfWork.SaveChangesAsync();

                return editBaby;
            }

            return null;
        }

        public async Task<string> DeleteBaby(int id)
        {
            var baby = unitOfWork.Babies.GetByID(id);

            if (baby != null)
            {
                unitOfWork.Babies.Delete(baby);
                await unitOfWork.SaveChangesAsync();
                return "Ok";
            }

            return "Error";
        }
    }
}
