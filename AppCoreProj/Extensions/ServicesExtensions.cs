using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using LoggerServices;
using Contracts;

namespace AppCoreProj.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
           services.AddCors(option =>
           {
               option.AddPolicy("CorsPloicy", builder =>
               {
                   builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
               });
           });

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
          services.AddDbContext<DbcontextRepo>(opt =>
          opt.UseSqlServer(configuration.GetConnectionString("DBConnection"),
              builder=>builder.MigrationsAssembly("AppCoreProj")
              )             
              );

        public static void ConfigureLoggerServices(this IServiceCollection services) =>
          services.AddScoped<ILoggerManager, LoggerManager>();
    }
}
