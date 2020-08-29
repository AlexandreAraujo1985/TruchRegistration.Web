using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TruckRegistration.Application.Interfaces;
using TruckRegistration.Application.Services;
using TruckRegistration.Domain.Interfaces.Repositories;
using TruckRegistration.Domain.Interfaces.Services;
using TruckRegistration.Domain.Services;
using TruckRegistration.Infra.Data.Contexts;
using TruckRegistration.Infra.Data.Repositories;

namespace TruckRegistration
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            #region Scoped
            services.AddScoped<ITruckApplication, TruckApplication>();
            services.AddScoped<ITruckService, TruckService>();
            services.AddScoped<ITruckRepository, TruckRepository>();

            services.AddScoped<ITruckModelApplication, TruckModelApplication>();
            services.AddScoped<ITruckModelService, TruckModelService>();
            services.AddScoped<ITruckModelRepository, TruckModelRepository>();
            #endregion

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<TruckRegistrationContext>(options =>
                options.UseSqlServer(@"Data Source =.\sqlexpress; Initial Catalog = truck_registration; Integrated Security = True"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(configure => configure.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}"));
        }
    }
}