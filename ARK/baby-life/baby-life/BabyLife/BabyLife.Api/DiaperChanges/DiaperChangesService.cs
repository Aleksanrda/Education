using BabyLife.Api.DiaperChanges.DTO;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.DiaperChanges
{
    public class DiaperChangesService : IDiaperChangesService
    {
        private readonly IUnitOfWork unitOfWork;

        public DiaperChangesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PostDiaperChanges> GetDiaperChanges()
        {
            var result = unitOfWork.DiaperChanges.GetAll().Select(x =>
           new PostDiaperChanges()
           {
               Name = x.Name,
               TimeDiaper = x.TimeDiaper,
               Reason = x.Reason,
           }).ToList();

            return result;
        }

        public List<DiaperChange> GetBabyDiaperChanges(int babyId)
        {
            var diaperChanges = unitOfWork.DiaperChanges.GetAll();

            var babyDiaperChanges = diaperChanges.Where(diaperChange => diaperChange.BabyId == babyId).ToList();

            return babyDiaperChanges;
        }

        public DiaperChange GetDiaperChange(int id)
        {
            var result = unitOfWork.DiaperChanges.GetAllLazyLoad(s => s.Id == id, s => s.Baby).AsNoTracking().First();
            
            var diaperChange = new DiaperChange()
            {
                Id = result.Id,
                Name = result.Name,
                TimeDiaper = result.TimeDiaper,
                Reason = result.Reason,
                BabyId = result.BabyId,
                Baby = new Baby()
                {
                    Id = result.BabyId
                }
            };

            return diaperChange;
        }

        public async Task<DiaperChange> CreateDiaperChange(PostDiaperChanges diaperChangesDTO, int babyId)
        {
            if (diaperChangesDTO == null)
            {
                throw new ArgumentNullException(nameof(diaperChangesDTO));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == babyId);

            var diaperChange = new DiaperChange()
            {
                Name = diaperChangesDTO.Name,
                TimeDiaper = diaperChangesDTO.TimeDiaper,
                Reason = diaperChangesDTO.Reason,
            };

            if (baby != null)
            {
                diaperChange.BabyId = babyId;
                diaperChange.Baby = baby;

                unitOfWork.DiaperChanges.Create(diaperChange);
                await unitOfWork.SaveChangesAsync();

                return diaperChange;
            }

            return null;
        }

        public async Task<DiaperChange> UpdateDiaperChange(DiaperChange editDiaperChange)
        {
            if (editDiaperChange == null)
            {
                throw new ArgumentNullException(nameof(editDiaperChange));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == editDiaperChange.BabyId);

            var diaperChanges = unitOfWork.DiaperChanges.GetAll();
            var diaperChange = diaperChanges.FirstOrDefault(
                sleeping => sleeping.Id == editDiaperChange.Id);

            if (diaperChange != null)
            {
                diaperChange.Name = editDiaperChange.Name;
                diaperChange.TimeDiaper = editDiaperChange.TimeDiaper;
                diaperChange.Reason = editDiaperChange.Reason;
            }

            if (baby != null)
            {
                diaperChange.BabyId = editDiaperChange.BabyId;
                diaperChange.Baby = baby;

                unitOfWork.DiaperChanges.Update(diaperChange);
                await unitOfWork.SaveChangesAsync();

                return diaperChange;
            }

            return null;
        }

        public async Task<string> DeleteDiaperChange(int id)
        {
            var diaperChange = unitOfWork.DiaperChanges.GetByID(id);

            if (diaperChange != null)
            {
                unitOfWork.DiaperChanges.Delete(diaperChange);
                await unitOfWork.SaveChangesAsync();
                return "Ok";
            }

            return "Error";
        }
    }
}
