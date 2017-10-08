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
                services.AddTransient<IUserAccessHandler, GuestUserAccessHandler>();
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

            services.AddSingleton<INameResolver, ApplicationResolver>();
            //services.AddSingleton<IConfigurationManager>( s => {

            //    var nameResolver = s.GetService<INameResolver>();
            //    var keyStore = new MemoryDataStore();
            //    var configStore = new SecureDataStore(new MemoryDataStore());

            //    var config = new ConfigurationManager(nameResolver, keyStore, configStore);

            //    return config;
            //});
            services.AddSingleton<ILocatorManager, LocatorManager>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                // QueryStringAuthenticationMiddleware.AddScheme<QueryAuthOptions, QueryStringAuthenticationHandler>("qswhat", o => { o.ClaimsIssuer = "qswhat-issuer"; })
                //.AddOAuth("git", o => {
                //    //AuthenticationScheme = "GitHub",
                //    //DisplayName = "GitHub",
                //    o.ClientId = Configuration["GitHub:ClientId"];
                //    o.ClientSecret = Configuration["GitHub:ClientSecret"];
                //    o.CallbackPath = new Microsoft.AspNetCore.Http.PathString("/signin-github");
                //    o.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
                //    o.TokenEndpoint = "https://github.com/login/oauth/access_token";
                //    o.UserInformationEndpoint = "https://api.github.com/user";
                //    o.ClaimsIssuer = "OAuth2-Github";
                //    o.SaveTokens = true;
                    
                //    // Retrieving user information is unique to each provider.
                //    o.Events = new OAuthEvents
                //    {
                //        OnCreatingTicket = async context => { await CreateGitHubAuthTicket(context); }
                //    };
                //})
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

            app.UseMvc();
            
            SeedMockupData(services);
        }

        void SeedMockupData(IServiceProvider services)
        {
            // create myapp001
            //var configManager = services.GetService<IConfigurationManager>();
            //((ConfigurationManager)configManager).Create("myapp001", "dev", "{secrets}");

            var configSrv = services.GetService<IConfigServerManager<AppResource>>();
            configSrv.Create(null, new AppResource("myapp001", "dev"), new StringData("{secrets}"));

        }

        private static async Task CreateGitHubAuthTicket(OAuthCreatingTicketContext context)
        {
            // Get the GitHub user
            var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, context.Options.UserInformationEndpoint);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", context.AccessToken);
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();

            var res = Newtonsoft.Json.Linq.JObject.Parse(content);
            string login = res.GetValue("login").ToString();
            context.Identity.AddClaim(new System.Security.Claims.Claim("nome", login));

            //var user = JObject.Parse();
            //            AddClaims(context, user);
        }
    }
}
