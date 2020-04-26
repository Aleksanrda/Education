using BabyLife.Api.Bathings.DTO;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Bathings
{
    public class BathingsService : IBathingsService
    {
        private readonly IUnitOfWork unitOfWork;

        public BathingsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PostBathingDTO> GetBathings()
        {
            var result = unitOfWork.Bathings.GetAll().Select(x =>
           new PostBathingDTO()
           {
               Name = x.Name,
               StartTime = x.StartTime,
               EndTime = x.EndTime,
               WaterTemperature = x.WaterTemperature,
               Baby = new Baby()
               {
                   Id = x.BabyId
               }
           }).ToList();

            return result;
        }

        public PostBathingDTO GetBathing(int id)
        {
            var result = unitOfWork.Bathings.GetAllLazyLoad(b => b.Id == id, b => b.Baby).AsNoTracking().First();

            var bathing = new PostBathingDTO()
            {
                Name = result.Name,
                StartTime = result.StartTime,
                EndTime = result.EndTime,
                WaterTemperature = result.WaterTemperature,
                Baby = new Baby()
                {
                    Id = result.BabyId
                }
            };

            return bathing;
        }

        public async Task<Bathing> CreateBathing(PostBathingDTO bathingDTO)
        {
            if (bathingDTO == null)
            {
                throw new ArgumentNullException(nameof(bathingDTO));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == bathingDTO.Baby.Id);

            var bathing = new Bathing()
            {
                Name = bathingDTO.Name,
                StartTime = bathingDTO.StartTime,
                EndTime = bathingDTO.EndTime,
                WaterTemperature = bathingDTO.WaterTemperature,
            };

            if (baby != null)
            {
                bathing.BabyId = bathingDTO.Baby.Id;
                bathing.Baby = baby;

                unitOfWork.Bathings.Create(bathing);
                await unitOfWork.SaveChangesAsync();

                return bathing;
            }

            return null;
        }

        public async Task<Bathing> UpdateBathing(int id, PostBathingDTO bathingDTO)
        {
            if (bathingDTO == null)
            {
                throw new ArgumentNullException(nameof(bathingDTO));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == bathingDTO.Baby.Id);

            var bathings = unitOfWork.Bathings.GetAll();
            var bathing = bathings.FirstOrDefault(
                bathing => bathing.Id == id);

            if (bathing != null)
            {
                bathing.Name = bathingDTO.Name;
                bathing.StartTime = bathingDTO.StartTime;
                bathing.EndTime = bathingDTO.EndTime;
                bathing.WaterTemperature = bathingDTO.WaterTemperature;
            }

            if (baby != null)
            {
                bathing.BabyId = bathingDTO.Baby.Id;
                bathing.Baby = baby;

                unitOfWork.Bathings.Update(bathing);
                await unitOfWork.SaveChangesAsync();

                return bathing;
            }

            return null;
        }

        public async Task<string> DeleteBathing(int id)
        {
            var bathing = unitOfWork.Bathings.GetByID(id);

            if (bathing != null)
            {
                unitOfWork.Sleepings.Delete(bathing);
                await unitOfWork.SaveChangesAsync();
                return "Ok";
            }

            return "Error";
        }
    }
}
