using System;
using Core.Services;
using Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            this.Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddMvc();
            // var database = Configuration["database"] ?? "Shope";
            // var port = Configuration["dbport"] ?? "8080";
            // var user = Configuration["dbuser"] ?? "SA";
            // var password = Configuration["dbpassword"] ?? "yourStrongPassword@123";
            // var server = Configuration["dbserver"] ?? "shopedb";
            // services.AddDbContext<ShopeDbContext>(opt =>
            // {
            //     opt.UseSqlServer($"Server={server},{port};Initial Catalog={database};User Id={user};Password={password}");
            // });
             services.AddDbContext<ShopeDbContext>(opt =>
            {
                opt.UseSqlServer($"Data Source=.;initial catalog=Shope;integrated security=true");
            });
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ICommonServices, CommonServices>();
            services.AddScoped<IPostServices, PostServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IRoleService, RoleServices>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{Controller=Home}/{Action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "Area",
                    pattern: "{Area=exists}/{Controller=Home}/{Action=Index}/{id?}"
                );
            });
        }
    }
}
