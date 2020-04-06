using Babylife.Core.Entities;
using Babylife.Core.Repositories;
using BabyLife.Api.Accounts;
using BabyLife.Api.Babies;
using BabyLife.Api.Users;
using BabyLife.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterBabyLifeServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IBabiesService, BabiesService>();
            services.AddScoped<IAccountsService, AccountsService>();

            services.AddTransient<IRepositoryBase<User>, BaseRepository<User>>();
            services.AddTransient<IRepositoryBase<Baby>, BaseRepository<Baby>>();

            return services;
        }
    }
}
