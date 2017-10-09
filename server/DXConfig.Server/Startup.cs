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
            services.AddSingleton<IUserManager>(s => new UserManager(new PassKeyServices("123")));

            services.AddSingleton<ILocationManager<AppResource>, AppResourceLocationManager>();
            //services.AddSingleton<ILocationManager<AppLink>, AppLinkLocationManager>();
            services.AddSingleton<IStorageManager>( svcs => {
                return new StorageManager(FileDataStore.Create("tmp/apps"));
            });
            
            services.AddSingleton<IConfigServerManager<AppLink>>(svcs => {
                var location = new AppLinkLocationManager(FileDataStore.Create("tmp/links"));                
                var storage = new StorageManager(FileDataStore.Create("tmp/links"));
                return new ConfigServerManager<AppLink>(location, storage);
            });

            services.AddSingleton<IConfigServerManager<AppResource>>( svcs => {
                var location = svcs.GetService<ILocationManager<AppResource>>();
                var storage = svcs.GetService<IStorageManager>();
                
                return new ConfigServerManager<AppResource>(location, storage);
            });
            
            if (Env.EnvironmentName == "Test") // || (Env.IsProduction() == false)
            {
                services.AddTransient<IUserAccessHandler, GeneralUserAccessHandler>();
                services.Configure<GeneralUserAccessHandlerOptions>(o => { o.Username = "testuser"; });
            }
            else
            {
                services.AddTransient<IUserAccessHandler, UserAccessHandler>();

                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.AccessDeniedPath = "/AccountForbidden";
                    options.LoginPath = "/portal/login";
                })
                .AddGithub(o =>
                {
                    o.ClientId = Configuration["GitHub:ClientId"];
                    o.ClientSecret = Configuration["GitHub:ClientSecret"];
                });
            }

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
                    defaults: new { controller = "WebPortal", action = "index" });

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
