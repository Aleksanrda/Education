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

        PostDiaperChanges GetDiaperChange(int id);

        Task<DiaperChange> CreateDiaperChange(PostDiaperChanges diaperChangesDTO);

        Task<DiaperChange> UpdateDiaperChange(int id, PostDiaperChanges diaperChangesDTO);

        Task<string> DeleteDiaperChange(int id);
    }
}
