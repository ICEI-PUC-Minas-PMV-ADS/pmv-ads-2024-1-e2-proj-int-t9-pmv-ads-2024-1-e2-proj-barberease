using AutoMapper;
using BarberEaseApi.Database;
using BarberEaseApi.Interfaces.Repositories;
using BarberEaseApi.Interfaces.Services;
using BarberEaseApi.Mappers;
using BarberEaseApi.Repositories;
using BarberEaseApi.Services;
using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();

            // Services
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IEstablishmentService, EstablishmentService>();

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

            // Cors
            services.AddCors((options) =>
            {
                options.AddPolicy("CorsPolicy", (policy) =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
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

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseEndpoints((endpoints) => endpoints.MapControllers());

            if (Environment.GetEnvironmentVariable("DB_APPLY_AUTO_MIGRATION")?.ToLower() == "true")
            {
                using var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                using var context = service.ServiceProvider.GetService<AppDbContext>();
                context?.Database.Migrate();
            }
        }
    }
}
