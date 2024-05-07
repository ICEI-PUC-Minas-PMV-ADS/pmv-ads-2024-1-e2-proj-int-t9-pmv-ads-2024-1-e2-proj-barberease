using Microsoft.OpenApi.Models;

namespace BarberEaseApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BarberEase API",
                    Description = "College Project BarberEase API"
                });
            });

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
