using BabyLife.Api.DiaperChanges.DTO;
using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.DiaperChanges
{
    public interface IDiaperChangesService
    {
        IEnumerable<PostDiaperChanges> GetDiaperChanges();

        List<DiaperChange> GetBabyDiaperChanges(int babyId);

        DiaperChange GetDiaperChange(int id);

        Task<DiaperChange> CreateDiaperChange(PostDiaperChanges diaperChangesDTO, int babyId);

        Task<DiaperChange> UpdateDiaperChange(DiaperChange editDiaperChange);

        Task<string> DeleteDiaperChange(int id);
    }
}
