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

        PostSleepingDTO GetSleeping(int id);

        Task<Sleeping> CreateSleeping(PostSleepingDTO sleepingDTO);

        Task<Sleeping> UpdateSleeping(int id, PostSleepingDTO sleepingDTO);

        Task<string> DeleteSleeping(int id);
    }
}
