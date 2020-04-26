﻿using BabyLife.Api.Accounts;
using BabyLife.Api.Babies;
using BabyLife.Api.Roles;
using BabyLife.Api.Users;
using BabyLife.Core.Entities;
using BabyLife.Core.Repositories;
using BabyLife.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Mobile
{
    public static class ServiceExtension
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
            services.AddScoped<IBabiesService, BabiesService>();

            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Baby>, Repository<Baby>>();
            services.AddTransient<IRepository<Reminder>, Repository<Reminder>>();
            services.AddTransient<IRepository<Device>, Repository<Device>>();
            services.AddTransient<IRepository<Sleeping>, Repository<Sleeping>>();
            services.AddTransient<IRepository<Bathing>, Repository<Bathing>>();
            services.AddTransient<IRepository<Feeding>, Repository<Feeding>>();
            services.AddTransient<IRepository<DiaperChange>, Repository<DiaperChange>>();

            return services;
        }
    }
}
