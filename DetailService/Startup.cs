using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DetailService.Data;
using DetailService.SyncDataServices.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DetailService
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment _env;

        public void ConfigureServices(IServiceCollection services)
        {
             if (_env.IsProduction())
            {
                Console.WriteLine("--> Using SqlServer Db");
                services.AddDbContext<AppDbContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("DetailsConn")));
            }
            else
            {
                Console.WriteLine("--> Using InMem Db");
                services.AddDbContext<AppDbContext>(opt =>
                     opt.UseInMemoryDatabase("InMem"));
            }
                

            services.AddScoped<IDetailRepo, DetailRepo>();


            services.AddHttpClient<IProviderDataClient, HttpProviderDataClient>();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DetailService", Version = "v1" });
            });

            Console.WriteLine($"--> ProvidersService Endpoint {Configuration["ProvidersService"]}");
            
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DetailService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDb.PrepPopulation(app, env.IsProduction());

        }
    }
}
