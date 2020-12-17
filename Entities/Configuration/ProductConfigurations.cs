using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
            (
                  new Product
                  {  
                      Id=1,
                      Name = "ProductTst1",
                      Price = 1200,
                      LastUpdated = "12/3/2013",
                      Photo = ""
                  },
                 new Product
                 {
                     Id=2,
                     Name = "ProductTst1",
                     Price = 1200,
                     LastUpdated = "12/3/2013",
                     Photo = ""
                 }
            );

        }
    }
}