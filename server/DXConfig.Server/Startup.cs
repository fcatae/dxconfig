using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Infra;
using DXConfig.Server.Interfaces;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using DXConfig.Server.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DXConfig.Server
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
            //services.AddTransient<IDataStore, MemoryDataStore>();
            //services.AddTransient<ISecureDataStore, SecureDataStore>();

            services.AddSingleton<INameResolver, ApplicationResolver>();

            services.AddSingleton<IConfigurationManager>( s => {

                var nameResolver = s.GetService<INameResolver>();
                var keyStore = new MemoryDataStore();
                var configStore = new SecureDataStore(new MemoryDataStore());

                var config = new ConfigurationManager(nameResolver, keyStore, configStore);

                return config;
            });
            services.AddSingleton<ILocatorManager, LocatorManager>();

            services.AddAuthentication()
                .AddScheme<QueryAuthOptions,QueryStringAuthenticationHandler>("qswhat", o => { o.ClaimsIssuer = "qswhat-issuer"; })
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

            app.UseMvc();
            
            SeedMockupData(services);
        }

        void SeedMockupData(IServiceProvider services)
        {
            // create myapp001
            var configManager = services.GetService<IConfigurationManager>();
            ((ConfigurationManager)configManager).Create("myapp001", "dev", "{secrets}");
        }
    }
}
