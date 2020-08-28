namespace HotelsApp.Api
{
    using HotelsApp.Application.Services;
    using HotelsApp.Core.Contracts.Repositories;
    using HotelsApp.Core.Contracts.Services;
    using HotelsApp.Data;
    using HotelsApp.Data.Repository;
    using HotelsApp.Infrastructure.HereMap;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors();

            services.AddScoped<IBookingsRepository, BookingsRepository>();
            services.AddScoped<IPropertiesRepository, PropertiesRepository>();
            services.AddScoped<IHereMapService, HereMapService>();
            services.AddScoped<IBookingService, BookingService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                dbContext.Database.EnsureCreated();
            }

            app.UseHttpsRedirection()
                .UseRouting()
                .UseCors(x => x.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod())
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}