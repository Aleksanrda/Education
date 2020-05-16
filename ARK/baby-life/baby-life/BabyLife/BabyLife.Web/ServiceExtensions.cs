using BabyLife.Api.Accounts;
using BabyLife.Api.Babies;
using BabyLife.Api.Bathings;
using BabyLife.Api.Devices;
using BabyLife.Api.DiaperChanges;
using BabyLife.Api.Feedings;
using BabyLife.Api.Reminders;
using BabyLife.Api.Roles;
using BabyLife.Api.Sleepings;
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
            services.AddScoped<IBabiesService, BabiesService>();
            services.AddScoped<IRemindersService, RemindersService>();
            services.AddScoped<ISleepingsService, SleepingsService>();
            services.AddScoped<IBathingsService, BathingsService>();
            services.AddScoped<IDiaperChangesService, DiaperChangesService>();
            services.AddScoped<IDevicesService, DevicesService>();
            services.AddScoped<IFeedingsService, FeedingsService>();

            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Baby>, Repository<Baby>>();
            services.AddTransient<IRepository<Reminder>, Repository<Reminder>>();
            services.AddTransient<IRepository<Sleeping>, Repository<Sleeping>>();
            services.AddTransient<IRepository<Bathing>, Repository<Bathing>>();
            services.AddTransient<IRepository<DiaperChange>, Repository<DiaperChange>>();
            services.AddTransient<IRepository<Feeding>, Repository<Feeding>>();
            services.AddTransient<IRepository<Device>, Repository<Device>>();

            services.AddHostedService<BabyHostedService>();

            return services;
        }
    }
}
