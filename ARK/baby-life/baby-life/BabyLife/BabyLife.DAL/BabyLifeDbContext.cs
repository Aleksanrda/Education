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
    }
}
