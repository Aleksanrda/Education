using BabyLife.Api.Bathings.DTO;
using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Bathings
{
    public interface IBathingsService
    {
        IEnumerable<PostBathingDTO> GetBathings();

        PostBathingDTO GetBathing(int id);

        Task<Bathing> CreateBathing(PostBathingDTO bathingDTO);

        Task<Bathing> UpdateBathing(int id, PostBathingDTO bathingDTO);

        Task<string> DeleteBathing(int id);
    }
}
