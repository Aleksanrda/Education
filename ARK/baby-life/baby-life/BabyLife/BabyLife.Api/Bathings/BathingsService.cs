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
           }).ToList();

            return result;
        }

        public List<Bathing> GetBabyBathings(int babyId)
        {
            var bathings = unitOfWork.Bathings.GetAll();

            var babyBathings = bathings.Where(bathing => bathing.BabyId == babyId).ToList();

            return babyBathings;
        }

        public Bathing GetBathing(int id)
        {
            var result = unitOfWork.Bathings.GetAllLazyLoad(b => b.Id == id, b => b.Baby).AsNoTracking().First();

            var bathing = new Bathing()
            {
                Id = id,
                Name = result.Name,
                StartTime = result.StartTime,
                EndTime = result.EndTime,
                WaterTemperature = result.WaterTemperature,
                BabyId = result.BabyId,
                Baby = new Baby()
                {
                    Id = result.BabyId
                }
            };

            return bathing;
        }

        public async Task<Bathing> CreateBathing(PostBathingDTO bathingDTO, int babyId)
        {
            if (bathingDTO == null)
            {
                throw new ArgumentNullException(nameof(bathingDTO));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == babyId);

            var bathing = new Bathing()
            {
                Name = bathingDTO.Name,
                StartTime = bathingDTO.StartTime,
                EndTime = bathingDTO.EndTime,
                WaterTemperature = bathingDTO.WaterTemperature,
            };

            if (baby != null)
            {
                bathing.BabyId = babyId;
                bathing.Baby = baby;

                unitOfWork.Bathings.Create(bathing);
                await unitOfWork.SaveChangesAsync();

                return bathing;
            }

            return null;
        }

        public async Task<Bathing> UpdateBathing(Bathing editBathing)
        {
            if (editBathing == null)
            {
                throw new ArgumentNullException(nameof(editBathing));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == editBathing.BabyId);

            var bathings = unitOfWork.Bathings.GetAll();
            var bathing = bathings.FirstOrDefault(
                bathing => bathing.Id == editBathing.Id);

            if (bathing != null)
            {
                bathing.Name = editBathing.Name;
                bathing.StartTime = editBathing.StartTime;
                bathing.EndTime = editBathing.EndTime;
                bathing.WaterTemperature = editBathing.WaterTemperature;
            }

            if (baby != null)
            {
                bathing.BabyId = editBathing.BabyId;
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
                unitOfWork.Bathings.Delete(bathing);
                await unitOfWork.SaveChangesAsync();
                return "Ok";
            }

            return "Error";
        }
    }
}
