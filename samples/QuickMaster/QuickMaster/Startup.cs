using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuickMaster.Models;

namespace QuickMaster
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
            services.AddControllersWithViews();
            services.AddDbContext<MyContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MyContext")));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}",
                    constraints: new
                    {
                        id = @"\d{1,3}"
                    }
                );
                endpoints.MapControllerRoute(
                    name: "ArticleRoute",
                    pattern: "Articles/{id}",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Test"
                    }
                );
                endpoints.MapControllerRoute(
                    name: "ForumRoute",
                    pattern: "Articles/{forum}_{category}/{author}-{id}",

                    defaults: new
                    {
                        controller = "Home",
                        action = "Test2"
                    }
                );
                endpoints.MapControllerRoute(
                    name: "SearchRoute",
                    pattern: "Search/{*keywords}",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Test3"
                    }
                );
            });
        }
    }
}