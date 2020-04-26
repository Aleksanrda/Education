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
               Device = new Device()
               {
                   Id = x.DeviceId
               },
               Baby = new Baby()
               {
                   Id = x.BabyId
               }
           }).ToList();

            return result;
        }

        public PostFeedingsDTO GetFeeding(int id)
        {
            var result = unitOfWork.Feedings.GetAllLazyLoad(f => f.Id == id, f => f.Baby, f => f.Device).AsNoTracking().First();

            var feeding = new PostFeedingsDTO()
            {
                Name = result.Name,
                CountMilk = result.CountMilk,
                TimeMilk = result.TimeMilk,
                Device = new Device()
                {
                    Id = result.DeviceId
                },
                Baby = new Baby()
                {
                    Id = result.BabyId
                }
            };

            return feeding;
        }

        public async Task<Feeding> CreateFeeding(PostFeedingsDTO feedingDTO)
        {
            if (feedingDTO == null)
            {
                throw new ArgumentNullException(nameof(feedingDTO));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == feedingDTO.Baby.Id);

            var devices = unitOfWork.Devices.GetAll();
            var device = devices.FirstOrDefault(
                device => device.Id == feedingDTO.Device.Id);

            var feeding = new Feeding()
            {
                Name = feedingDTO.Name,
                CountMilk = feedingDTO.CountMilk,
                TimeMilk = feedingDTO.TimeMilk
            };

            if (baby != null && device != null)
            {
                feeding.DeviceId = feedingDTO.Device.Id;
                feeding.Device = device;

                feeding.BabyId = feedingDTO.Baby.Id;
                feeding.Baby = baby;

                unitOfWork.Feedings.Create(feeding);
                await unitOfWork.SaveChangesAsync();

                return feeding;
            }

            return null;
        }

        public async Task<Feeding> UpdateFeeding(int id, PostFeedingsDTO feedingDTO)
        {
            if (feedingDTO == null)
            {
                throw new ArgumentNullException(nameof(feedingDTO));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == feedingDTO.Baby.Id);

            var devices = unitOfWork.Devices.GetAll();
            var device = devices.FirstOrDefault(
                device => device.Id == feedingDTO.Device.Id);

            var feedings = unitOfWork.Feedings.GetAll();
            var feeding = feedings.FirstOrDefault(
                feeding => feeding.Id == id);

            if (feeding != null)
            {
                feeding.Name = feedingDTO.Name;
                feeding.CountMilk = feedingDTO.CountMilk;
                feeding.TimeMilk = feedingDTO.TimeMilk;
            }

            if (baby != null && device != null)
            {
                feeding.DeviceId = feedingDTO.Device.Id;
                feeding.Device = device;

                feeding.BabyId = feedingDTO.Baby.Id;
                feeding.Baby = baby;

                unitOfWork.Feedings.Update(feeding);
                await unitOfWork.SaveChangesAsync();

                return feeding;
            }

            return null;
        }

        public async Task<string> DeleteFeeding(int id)
        {
            var feeding = unitOfWork.Devices.GetByID(id);

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
