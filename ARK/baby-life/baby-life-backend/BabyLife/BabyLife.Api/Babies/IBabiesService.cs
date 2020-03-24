using Babylife.Core.Entities;
using BabyLife.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Api.Babies
{
    public interface IBabiesService
    {
        CollectionResult<Baby> GetBabies(int skip, int take);
    }
}
