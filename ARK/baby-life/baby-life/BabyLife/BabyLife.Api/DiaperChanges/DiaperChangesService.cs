﻿using BabyLife.Api.DiaperChanges.DTO;
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
               Baby = new Baby()
               {
                   Id = x.BabyId
               }
           }).ToList();

            return result;
        }

        public PostDiaperChanges GetDiaperChange(int id)
        {
            var result = unitOfWork.DiaperChanges.GetAllLazyLoad(s => s.Id == id, s => s.Baby).AsNoTracking().First();
            
            var diaperChange = new PostDiaperChanges()
            {
                TimeDiaper = result.TimeDiaper,
                Reason = result.Reason,
                Baby = new Baby()
                {
                    Id = result.BabyId
                }
            };

            return diaperChange;
        }

        public async Task<DiaperChange> CreateDiaperChange(PostDiaperChanges diaperChangesDTO)
        {
            if (diaperChangesDTO == null)
            {
                throw new ArgumentNullException(nameof(diaperChangesDTO));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == diaperChangesDTO.Baby.Id);

            var diaperChange = new DiaperChange()
            {
                TimeDiaper = diaperChangesDTO.TimeDiaper,
                Reason = diaperChangesDTO.Reason,
            };

            if (baby != null)
            {
                diaperChange.BabyId = diaperChangesDTO.Baby.Id;
                diaperChange.Baby = baby;

                unitOfWork.DiaperChanges.Create(diaperChange);
                await unitOfWork.SaveChangesAsync();

                return diaperChange;
            }

            return null;
        }

        public async Task<DiaperChange> UpdateDiaperChange(int id, PostDiaperChanges diaperChangesDTO)
        {
            if (diaperChangesDTO == null)
            {
                throw new ArgumentNullException(nameof(diaperChangesDTO));
            }

            var babies = unitOfWork.Babies.GetAll();
            var baby = babies.FirstOrDefault(
                baby => baby.Id == diaperChangesDTO.Baby.Id);

            var diaperChanges = unitOfWork.DiaperChanges.GetAll();
            var diaperChange = diaperChanges.FirstOrDefault(
                sleeping => sleeping.Id == id);

            if (diaperChange != null)
            {
                diaperChange.TimeDiaper = diaperChangesDTO.TimeDiaper;
                diaperChange.Reason = diaperChangesDTO.Reason;
            }

            if (baby != null)
            {
                diaperChange.BabyId = diaperChangesDTO.Baby.Id;
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
