using Babylife.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BabyLife.DataAccess
{
    public class BabyLifeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Baby> Babies { get; set; }

        public BabyLifeDbContext()
        {
        }

        public BabyLifeDbContext(DbContextOptions<BabyLifeDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BabyLifeDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
