using AutoMapper;
using Demo.Prova.Common.Services;
using Demo.Prova.Core.Entities;
using Demo.Prova.Core.IRepositorys;
using Demo.Prova.Core.IServices;
using Demo.Prova.Core.Models;
using Demo.Prova.Infra.Context;
using Demo.Prova.Infra.Repositorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Demo.Prova.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["Connection:ConnectionString"];
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddScoped<IBaseRepository<Moedas>, BaseRepository<Moedas>>();
            services.AddScoped<IBaseService<Moedas>, BaseService<Moedas>>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateMoedasModel, Moedas>();
                config.CreateMap<UpdateMoedasModel, Moedas>();
                config.CreateMap<Moedas, MoedasModel>();
            }).CreateMapper());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo Rest Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo Rest Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
