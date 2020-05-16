using BabyLife.Api.Babies.DTO;
using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Babies
{
    public interface IBabiesService
    {
        IEnumerable<Baby> GetBabies();

        IEnumerable<Baby> GetUserBabies(string userId);

        Baby GetBaby(int id);

        Baby GetBaby(int id, string userId);

        Task<Baby> CreateBaby(PostBabyDTO baby, string userId);

        Task<Baby> UpdateBaby(Baby baby, string userId);

        Task<string> DeleteBaby(int id);
    }
}
