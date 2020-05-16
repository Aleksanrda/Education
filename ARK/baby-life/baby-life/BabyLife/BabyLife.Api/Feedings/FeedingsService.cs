using BabyLife.Api.Feedings.DTO;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Feedings
{
    public class FeedingsService : IFeedingsService
    {
        private readonly IUnitOfWork unitOfWork;

        public FeedingsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PostFeedingsDTO> GetFeedings()
        {
            var result = unitOfWork.Feedings.GetAll().Select(x =>
           new PostFeedingsDTO()
           {
               Name = x.Name,
               CountMilk = x.CountMilk,
               TimeMilk = x.TimeMilk,
               DeviceId = x.DeviceId
           }).ToList();

            return result;
        }

        public List<Feeding> GetBabyFeedings(int babyId)
        {
            var feedings = unitOfWork.Feedings.GetAll();

            var babyFeedings= feedings.Where(feeding => feeding.BabyId == babyId).ToList();

            return babyFeedings;
        }

        public Feeding GetFeeding(int id)
        {
            var result = unitOfWork.Feedings.GetAllLazyLoad(f => f.Id == id, f => f.Baby, f => f.Device).AsNoTracking().First();

            var feeding = new Feeding()
            {
                Id = id,
                Name = result.Name,
                CountMilk = result.CountMilk,
                TimeMilk = result.TimeMilk,
                BabyId = result.BabyId,
                Baby = new Baby()
                {
                    Id = result.BabyId
                },
                DeviceId = result.DeviceId,
                Device = new Device()
                {
                    Id = result.DeviceId
                },
            };

            return feeding;
        }

        public async Task<Feeding> CreateFeeding(PostFeedingsDTO feedingDTO, int babyId)
        {
            if (feedingDTO == null)
            {
                throw new ArgumentNullException(nameof(feedingDTO));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == babyId);

            var devices = unitOfWork.Devices.GetAll();
            var device = devices.FirstOrDefault(
                device => device.Id == feedingDTO.DeviceId);

            var feeding = new Feeding()
            {
                Name = feedingDTO.Name,
                CountMilk = feedingDTO.CountMilk,
                TimeMilk = feedingDTO.TimeMilk
            };

            if (baby != null && device != null)
            {
                feeding.DeviceId = feedingDTO.DeviceId;
                feeding.Device = device;

                feeding.BabyId = babyId;
                feeding.Baby = baby;

                unitOfWork.Feedings.Create(feeding);
                await unitOfWork.SaveChangesAsync();

                return feeding;
            }

            return null;
        }

        public async Task<Feeding> UpdateFeeding(Feeding editFeeding)
        {
            if (editFeeding == null)
            {
                throw new ArgumentNullException(nameof(editFeeding));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == editFeeding.Baby.Id);

            var devices = unitOfWork.Devices.GetAll();
            var device = devices.FirstOrDefault(
                device => device.Id == editFeeding.DeviceId);

            var feedings = unitOfWork.Feedings.GetAll();
            var feeding = feedings.FirstOrDefault(
                feeding => feeding.Id == editFeeding.Id);

            if (feeding != null)
            {
                feeding.Name = editFeeding.Name;
                feeding.CountMilk = editFeeding.CountMilk;
                feeding.TimeMilk = editFeeding.TimeMilk;
            }

            if (baby != null && device != null)
            {
                feeding.DeviceId = editFeeding.Device.Id;
                feeding.Device = device;

                feeding.BabyId = editFeeding.Baby.Id;
                feeding.Baby = baby;

                unitOfWork.Feedings.Update(feeding);
                await unitOfWork.SaveChangesAsync();

                return feeding;
            }

            return null;
        }

        public async Task<string> DeleteFeeding(int id)
        {
            var feeding = unitOfWork.Feedings.GetByID(id);

            if (feeding != null)
            {
                unitOfWork.Feedings.Delete(feeding);
                await unitOfWork.SaveChangesAsync();
                return "Ok";
            }

            return "Error";
        }
    }
}
