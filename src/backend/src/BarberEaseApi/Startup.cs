using AutoMapper;
using BarberEaseApi.Database;
using BarberEaseApi.Interfaces.Repositories;
using BarberEaseApi.Interfaces.Services;
using BarberEaseApi.Mappers;
using BarberEaseApi.Repositories;
using BarberEaseApi.Services;
using Microsoft.OpenApi.Models;

namespace BarberEaseApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Dependency injection.
            services.AddScoped<AppDbContext>();

            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IClientRepository, ClientRepository>();

            // Services
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IAuthService, AuthService>();

            // Mapper
            var mapperConfig = new MapperConfiguration((cfg) =>
            {
                cfg.AddProfile(new DtoToEntityProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Swagger
            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BarberEase API",
                    Description = "College Project BarberEase API"
                });
            });

            // Api
            services.AddEndpointsApiExplorer();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI((options) =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "BarberEase API");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseRouting();
            app.UseEndpoints((endpoints) => endpoints.MapControllers());
        }
    }
}
