using BabyLife.Api.Feedings.DTO;
using BabyLife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BabyLife.Api.Feedings
{
    public interface IFeedingsService
    {
        IEnumerable<PostFeedingsDTO> GetFeedings();

        List<Feeding> GetBabyFeedings(int babyId);

        Feeding GetFeeding(int id);

        Task<Feeding> CreateFeeding(PostFeedingsDTO feedingDTO, int babyId);

        Task<Feeding> UpdateFeeding(Feeding feeding);

        Task<string> DeleteFeeding(int id);
    }
}
