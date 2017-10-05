using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
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
            return new WebHostBuilder().UseStartup<DXConfig.Server.Startup>();
        }

        [Fact]
        public Task ConfigGetAll() => ValidateUrlAsync("/api/config");

        [Fact]
        public Task ConfigGetAppId() => ValidateUrlAsync("/api/config/myapp001");

        [Fact]
        public Task LocatorFindApplication() => ValidateUrlAsync("/api/locator/myapp?env=test");

        async Task<string> ValidateUrlAsync(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var configContent = await response.Content.ReadAsStringAsync();

            return configContent;
        }
    }
}
