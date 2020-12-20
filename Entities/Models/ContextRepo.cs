using Entities.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
  public  class DbcontextRepo :IdentityDbContext<User>
    {
        public DbcontextRepo()
        {

        }
        public DbcontextRepo(DbContextOptions<DbcontextRepo> options)
            : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfigurations());
            builder.ApplyConfiguration(new  ProductConfigurations());
        }
        public virtual DbSet<Product> Product { get; set; }
    }
}
