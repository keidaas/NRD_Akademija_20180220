﻿using akademija.Application.automapper;
using akademija.Application.main.employee;
using akademija.Application.main.inventory;
using akademija.Application.main.inventoryType;
using akademija.EF;
using akademija.EF.repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace akademija.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NrdAkademijaDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("AkademijaDatabase")));
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryTypeService, InventoryTypeService>();
            services.AddScoped<IInventoryTypeRepository, InventoryTypeRepository>();
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200")
           .AllowAnyHeader()
    );
            app.UseMvc();
        }
    }
}
