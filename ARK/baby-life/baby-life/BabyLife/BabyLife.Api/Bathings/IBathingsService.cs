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

        List<Bathing> GetBabyBathings(int babyId);

        Bathing GetBathing(int id);

        Task<Bathing> CreateBathing(PostBathingDTO bathingDTO, int babyId);

        Task<Bathing> UpdateBathing(Bathing editBathing);

        Task<string> DeleteBathing(int id);
    }
}
