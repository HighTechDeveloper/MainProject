using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RolesApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using RolesApp.Services;

namespace RolesApp
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
            //string connection = "Server=(localdb)\\mssqllocaldb;Database=rolestoredb2;Trusted_Connection=True;";
            string connection = "workstation id=LocalDb.mssql.somee.com;packet size=4096;user id=Viktor32167_SQLLogin_1;pwd=ez9km9m3fn;data source=LocalDb.mssql.somee.com;persist security info=False;initial catalog=LocalDb";



            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));//use postgre - установить отдельный пакет с посьтгре

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            });

            services.AddMvc();
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //// This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //options.CheckConsentNeeded = context => true;
            //options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IBookingService, BookingService>();

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
