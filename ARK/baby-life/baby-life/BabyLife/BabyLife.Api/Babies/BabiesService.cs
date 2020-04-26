using BabyLife.Api.Babies.DTO;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
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
            var result = unitOfWork.Babies.GetAll();

            return result;
        }

        public Baby GetBaby(int id)
        {
            var result = unitOfWork.Babies.GetByID(id);

            return result;
        }

        public async Task<Baby> CreateBaby(PostBabyDTO baby)
        {
            if (baby == null)
            {
                throw new ArgumentNullException(nameof(baby));
            }

            var users = unitOfWork.Users.GetAll();
            var user = users.FirstOrDefault(
                user => user.Email == baby.User.Email);

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
                newBaby.UserId = baby.User.Id;
                newBaby.User = user;

                unitOfWork.Babies.Create(newBaby);
                await unitOfWork.SaveChangesAsync();

                return newBaby;
            }

            return null;
        }

        public async Task<Baby> UpdateBaby(int id, PostBabyDTO baby)
        {
            if (baby == null)
            {
                throw new ArgumentNullException(nameof(baby));
            }

            var users = unitOfWork.Users.GetAll();
            var user = users.FirstOrDefault(
                user => user.Email == baby.User.Email);

            var babies = unitOfWork.Babies.GetAll();
            var editBaby = babies.FirstOrDefault(
                baby => baby.Id == id);

            if (editBaby != null)
            {
                editBaby.Name = baby.Name;
                editBaby.BloodType = baby.BloodType;
                editBaby.Allergies = baby.Allergies;
                editBaby.Notes = baby.Notes;
                editBaby.GenderType = (GenderType)Enum.Parse(typeof(GenderType), baby.GenderType);
            }

            if (user != null)
            {
                editBaby.UserId = baby.User.Id;
                editBaby.User = user;

                unitOfWork.Babies.Update(editBaby);
                await unitOfWork.SaveChangesAsync();

                return editBaby;
            }

            return null;
        }

        public async Task<string> DeleteBaby(int id)
        {
            var device = unitOfWork.Babies.GetByID(id);

            if (device != null)
            {
                unitOfWork.Babies.Delete(device);
                await unitOfWork.SaveChangesAsync();
                return "Ok";
            }

            return "Error";
        }
    }
}
