using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BabyLife.DAL
{
    public class BabyLifeDbContext : IdentityDbContext<User>
    {
        public BabyLifeDbContext(DbContextOptions<BabyLifeDbContext> options)
           : base(options) { }

        public DbSet<Baby> Babies { get; set; }

        public DbSet<Reminder> Reminders { get; set; }

        public DbSet<Sleeping> Sleepings { get; set; }

        public DbSet<Bathing> Bathings { get; set; }

        public DbSet<DiaperChange> DiaperChanges { get; set; }

        public DbSet<Feeding> Feedings { get; set; }

        public DbSet<Device> Devices { get; set; }
    }
}
