﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using LoggerServices;
using Contracts;
using Repository;
using Microsoft.AspNetCore.Identity;

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

        public static void ConfigureRepositroryManager(this IServiceCollection services) =>
          services.AddScoped<IRepositoryBase<Product>, RepositoryBase<Product>>();
       // services.AddScoped<IRepositoryManger, RepositoryManager>();

        public  static void ConfigureIdentity(this IServiceCollection Services)
        {
            var builder = Services.AddIdentityCore<User>(Us =>
              {
                  Us.Password.RequireDigit = true;
                  Us.Password.RequireLowercase = false;
                  Us.Password.RequireUppercase = false;
                  Us.Password.RequireNonAlphanumeric = false;
                  Us.Password.RequiredLength = 10;
                  Us.User.RequireUniqueEmail = true;

              });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<DbcontextRepo>().AddDefaultTokenProviders ();
        }
 
    }
}
