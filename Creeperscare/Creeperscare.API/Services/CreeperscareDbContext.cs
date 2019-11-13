using Creeperscare.Entities;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Creeperscare.DAL.Services
{
    public class CreeperscareDbContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        public DbSet<GardenPlot> GardenPlots { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<User> ProgramsUsers { get; set; }

        public CreeperscareDbContext(DbContextOptions<CreeperscareDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CreeperscareDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
