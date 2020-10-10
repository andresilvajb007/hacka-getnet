using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hacka_getnet.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace hacka_getnet
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
            services.AddControllers();
            services.AddDbContext<Context>(options => options.UseNpgsql("Host=ec2-18-211-86-133.compute-1.amazonaws.com; Port=5432;Database=d6lcvimj2nsnf6;Username=qrknctdtlwfoja;Password=eaf84382d7d50937d08c72b3615f021ed5dd1f119c5c56e21231f0d465b10f12;SSL Mode=Require; Trust Server Certificate=true;"));

            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(x => x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Version = "V1", Description = "API de Credito para o APP" })); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
