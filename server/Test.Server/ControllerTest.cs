using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DXConfig.Server.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Test.Server
{
    public class ControllerTest
    {
        TestServer _server;
        HttpClient _client;

        public ControllerTest()
        {
            _server = new TestServer(WebServerConfiguration());
            
            _client = _server.CreateClient();
        }

        IWebHostBuilder WebServerConfiguration()
        {
            return new WebHostBuilder()
                .UseEnvironment("Test")
                .UseStartup<DXConfig.Server.Startup>();
        }
        
        [Fact]
        public Task ConfigGetAll() => ValidateUrlAsync("/api/config");

        [Fact]
        public Task ConfigGetAppId() => ValidateUrlAsync("/api/config/myapp001");

        [Fact]
        public Task LocatorFindApplication() => ValidateUrlAsync("/api/locator/myapp?env=test");

        [Fact]
        public async Task LocatorAuthApplicationShouldFail()
        {
            var result = await ValidateUrlAsync("/api/locator/myapp?env=prod");

            if(result != null && result != "")
                throw new InvalidOperationException();
        }
        
        [Fact]
        public Task LocatorRootApplication() => ValidateUrlAsync("/api/locator/myapp?env=prod&authuser=root");

        async Task<string> ValidateUrlAsync(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            if (response.Content == null)
                return null;

            var configContent = await response.Content.ReadAsStringAsync();

            return configContent;
        }
    }
}
