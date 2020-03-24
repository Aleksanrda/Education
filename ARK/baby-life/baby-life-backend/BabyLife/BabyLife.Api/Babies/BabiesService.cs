using Babylife.Core.Entities;
using Babylife.Core.Repositories;
using BabyLife.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Api.Babies
{
    public class BabiesService : IBabiesService
    {
        private readonly IUnitOfWork unitOfWork;

        public BabiesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CollectionResult<Baby> GetBabies(int skip, int take)
        {
            var amount = unitOfWork.Babies.GetAll().Count();
            var babies = unitOfWork.Babies.GetAll().Skip(skip).Take(take).ToList();
            return new CollectionResult<Baby>(babies, amount);
        }
    }
}
