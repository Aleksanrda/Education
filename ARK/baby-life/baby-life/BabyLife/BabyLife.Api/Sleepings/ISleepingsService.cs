using BabyLife.Api.Sleepings.DTO;
using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Sleepings
{
    public interface ISleepingsService
    {
        IEnumerable<PostSleepingDTO> GetSleepings();

        List<Sleeping> GetBabySleepings(int babyId);

        Sleeping GetSleeping(int id);

        Task<Sleeping> CreateSleeping(PostSleepingDTO sleepingDTO, int babyId);

        Task<Sleeping> UpdateSleeping(Sleeping editSleeping);

        Task<string> DeleteSleeping(int id);
    }
}
