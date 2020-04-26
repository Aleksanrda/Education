using BabyLife.Api.Sleepings.DTO;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Sleepings
{
    public class SleepingsService : ISleepingsService
    {
        private readonly IUnitOfWork unitOfWork;

        public SleepingsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PostSleepingDTO> GetSleepings()
        {
            var result = unitOfWork.Sleepings.GetAll().Select(x =>
           new PostSleepingDTO()
           {
               Name = x.Name,
               StartTime = x.StartTime,
               EndTime = x.EndTime,
               Notes = x.Notes,
               Baby = new Baby()
               {
                   Id = x.BabyId
               }
           }).ToList();

            return result;
        }

        public PostSleepingDTO GetSleeping(int id)
        {
            var result = unitOfWork.Sleepings.GetAllLazyLoad(s => s.Id == id, s => s.Baby).AsNoTracking().First();

            var sleeping = new PostSleepingDTO()
            {
                Name = result.Name,
                StartTime = result.StartTime,
                EndTime = result.EndTime,
                Notes = result.Notes,
                Baby = new Baby()
                {
                    Id = result.BabyId
                }
            };

            return sleeping;
        }

        public async Task<Sleeping> CreateSleeping(PostSleepingDTO sleepingDTO)
        {
            if (sleepingDTO == null)
            {
                throw new ArgumentNullException(nameof(sleepingDTO));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == sleepingDTO.Baby.Id);

            var sleeping = new Sleeping()
            {
                Name = sleepingDTO.Name,
                StartTime = sleepingDTO.StartTime,
                EndTime = sleepingDTO.EndTime,
                Notes = sleepingDTO.Notes,
            };

            if (baby != null)
            {
                sleeping.BabyId = sleepingDTO.Baby.Id;
                sleeping.Baby = baby;

                unitOfWork.Sleepings.Create(sleeping);
                await unitOfWork.SaveChangesAsync();

                return sleeping;
            }

            return null;
        }

        public async Task<Sleeping> UpdateSleeping(int id, PostSleepingDTO sleepingDTO)
        {
            if (sleepingDTO == null)
            {
                throw new ArgumentNullException(nameof(sleepingDTO));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == sleepingDTO.Baby.Id);

            var sleepings = unitOfWork.Sleepings.GetAll();
            var sleeping = sleepings.FirstOrDefault(
                sleeping => sleeping.Id == id);

            if (sleeping != null)
            {
                sleeping.Name = sleepingDTO.Name;
                sleeping.StartTime = sleepingDTO.StartTime;
                sleeping.EndTime = sleepingDTO.EndTime;
                sleeping.Notes = sleepingDTO.Notes;
            }

            if (baby != null)
            {
                sleeping.BabyId = sleepingDTO.Baby.Id;
                sleeping.Baby = baby;

                unitOfWork.Sleepings.Update(sleeping);
                await unitOfWork.SaveChangesAsync();

                return sleeping;
            }

            return null;
        }

        public async Task<string> DeleteSleeping(int id)
        {
            var sleeping = unitOfWork.Sleepings.GetByID(id);

            if (sleeping != null)
            {
                unitOfWork.Sleepings.Delete(sleeping);
                await unitOfWork.SaveChangesAsync();
                return "Ok";
            }

            return "Error";
        }
    }
}
