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
        IEnumerable<PostBabyDTO> GetBabies();

        PostBabyDTO GetBaby(int id);

        Task<Baby> CreateBaby(PostBabyDTO baby);

        Task<Baby> UpdateBaby(int id, PostBabyDTO baby);

        Task<string> DeleteBaby(int id);
    }
}
