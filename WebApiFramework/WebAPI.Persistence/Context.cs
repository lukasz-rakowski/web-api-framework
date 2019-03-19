using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Entities.Base;
using WebAPI.Persistence.Configuration;

namespace WebAPI.Persistence
{
    public class Context : IdentityDbContext<User, Role, int>
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }

        public virtual DbSet<Product> Products { get; set; }
    }

    public class Product: EntityBaseWithHistory
    {
        public int Name { get; set; }
    }
}
