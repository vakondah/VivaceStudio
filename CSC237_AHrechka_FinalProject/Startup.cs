//CSC237
//Aliaksandra Hrechka
//05/08/2020

using CSC237_AHrechka_FinalProject.Hubs;
using CSC237_AHrechka_FinalProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CSC237_AHrechka_FinalProject
{
    public class Startup
    {
        // Loading configuration settings:
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VivaceContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("VivaceConnection")));

            services.AddMemoryCache();
            services.AddSession();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<VivaceContext>();

            services.AddControllersWithViews();
            services.AddSignalR();

            // makes URL lowercase with trailing slashes
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if statement is checking if we are running in development mode:
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chattingRoom");
            });
        }
    }
}
