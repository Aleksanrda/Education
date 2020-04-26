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

        PostFeedingsDTO GetFeeding(int id);

        Task<Feeding> CreateFeeding(PostFeedingsDTO feedingDTO);

        Task<Feeding> UpdateFeeding(int id, PostFeedingsDTO feedingDTO);

        Task<string> DeleteFeeding(int id);
    }
}
