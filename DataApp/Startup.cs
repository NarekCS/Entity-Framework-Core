﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataApp
{
    public class Startup
    {
        public Startup(IConfiguration config) => Configuration = config;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            string conString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<EFDatabaseContext>(options => options.UseSqlServer(conString));
            string customerConString = Configuration["ConnectionStrings:CustomerConnection"];
            services.AddDbContext<EFCustomerContext>(options => options.UseSqlServer(customerConString));

            services.AddTransient<IDataRepository, EFDataRepository>();
            services.AddTransient<ICustomerRepository, EFCustomerRepository>();
            services.AddTransient<MigrationsManager>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            //services.AddTransient<IGenericRepository<ContactDetails>, GenericRepository<ContactDetails>>();
            //services.AddTransient<IGenericRepository<ContactLocation>, GenericRepository<ContactLocation>>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EFDatabaseContext prodCtx, EFCustomerContext custCtx)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();            
            app.UseMvcWithDefaultRoute();
            if (env.IsDevelopment())
            {
                SeedData.Seed(prodCtx);
                SeedData.Seed(custCtx);
            }
        }
    }
}
