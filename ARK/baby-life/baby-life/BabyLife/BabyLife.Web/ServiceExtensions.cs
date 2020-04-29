using BabyLife.Api.Accounts;
using BabyLife.Api.Roles;
using BabyLife.Api.Users;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using BabyLife.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Web
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

            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRolesService, RolesService>();

            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Baby>, Repository<Baby>>();

            services.AddHostedService<BabyHostedService>();

            return services;
        }
    }
}
