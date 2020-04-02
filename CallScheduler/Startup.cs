using CallScheduler.Data;
using CallScheduler.Interfaces;
using CallScheduler.Models;
using CallScheduler.Schedules;
using CallScheduler.Services;
using FluentScheduler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CallScheduler
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add framework services.
            Utils.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CallSchedulerDbContext>(options => options.UseSqlServer(Utils.ConnectionString));
            // services.AddDbContext<CallSchedulerDbContext>(options => options.UseNpgsql(Utils.ConnectionString));
            services.AddIdentity<CustomUser, CustomRole>()
                            .AddEntityFrameworkStores<CallSchedulerDbContext>()
                            .AddDefaultTokenProviders();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            // configure DI for application services
            services.AddScoped<ICallService, CallService>();
            services.AddTransient<IEmailSender, NotifyService>();
            services.AddTransient<ISmsSender, NotifyService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IAuditService, AuditService>();
            services.AddScoped<IAuthorizationService, AuditService>();
            services.AddTransient<IImageHandler, ImageHandler>();
            services.AddTransient<IImageWriter, ImageWriter>();
            services.AddTransient<EmailSettings, EmailSettings>();
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
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            Task.Run(() =>
            {
                JobManager.Initialize(new ScheduleRegistry());
            });
        }
    }
}
