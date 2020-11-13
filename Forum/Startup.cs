using Forum.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Forum {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration["Data:ForumMessages:ConnectionString"]));

            services.AddTransient<IThemeRepository, EFThemeRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseBrowserLink();
            //app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{Id?}");
                endpoints.MapControllerRoute(
                    name: "Account",
                    pattern: "{controller}");
            });

            SeedData.EnsurePopulated(app);
            /*          
             *            
             *            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{Id?}"));*/
        }
    }
}
