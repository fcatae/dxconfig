using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Infra;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using DXConfig.Server.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DXConfig.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if(Env.EnvironmentName == "Test")
            {
                services.AddTransient<IUserAccessHandler, GeneralUserAccessHandler>();
                services.Configure<GeneralUserAccessHandlerOptions>(o => { o.Username = "testuser"; });
            }
            else
            {
                services.AddTransient<IUserAccessHandler, UserAccessHandler>();
            }

            services.AddSingleton<IUserManager>(s => new UserManager(new PassKeyServices("123")));

            services.AddSingleton<ILocationManager<AppResource>, AppResourceLocationManager>();
            services.AddSingleton<ILocationManager<AppLink>, AppLinkLocationManager>();
            services.AddSingleton<IStorageManager, StorageManager>();

            services.AddSingleton<IConfigServerManager<AppResource>, ConfigServerManager<AppResource>>();
            services.AddSingleton<IConfigServerManager<AppLink>, ConfigServerManager<AppLink>>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddGithub(o =>
                {
                    o.ClientId = Configuration["GitHub:ClientId"];
                    o.ClientSecret = Configuration["GitHub:ClientSecret"];
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {                    
                    options.AccessDeniedPath = "/AccountForbidden";
                    options.LoginPath = "/AccountUnauthorized";
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseQueryStringAuthentication();

            app.UseMvc( routes =>
            {
                routes.MapRoute(
                    name: "portal",
                    template: "portal/{action}",                    
                    defaults: new { controller = "Portal", action = "Index" });

                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller}");
            });
            
            SeedMockupData(services);
        }

        void SeedMockupData(IServiceProvider services)
        {
            var configSrv = services.GetService<IConfigServerManager<AppResource>>();
            configSrv.Create(null, new AppResource("myapp001", "dev"), new StringData("{secrets}"));
        }
    }
}
