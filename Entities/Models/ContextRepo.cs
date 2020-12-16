using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
  public  class DbcontextRepo : DbContext
    {
        public DbcontextRepo()
        {

        }
        public DbcontextRepo(DbContextOptions<DbcontextRepo> options)
            : base(options)
        {
                
        }
        public virtual DbSet<Product> Product { get; set; }
    }
}
