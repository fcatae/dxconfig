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

        [Fact(Skip = "Needs to configure DI")]
        public async Task GetAll()
        {
            // GET /api/config
            var response = await _client.GetAsync("/api/config");
            response.EnsureSuccessStatusCode();

            var configContent = response.Content.ReadAsStringAsync();
        }

        [Fact(Skip="Needs to configure DI")]
        public async Task GetAppId()
        {
            // GET /api/config/{appid}
            var response2 = await _client.GetAsync("/api/config/myapp001");
            response2.EnsureSuccessStatusCode();

            var configContent2 = response2.Content.ReadAsStringAsync();
        }
    }
}
