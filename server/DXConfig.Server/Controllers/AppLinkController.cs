using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Infra;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace DXConfig.Server.Controllers
{
    [Route("api/[controller]")]
    public class AppLinkController : Controller
    {
        AppResourceLocationManager appResourceLocation = new AppResourceLocationManager();

        IConfigServerManager<AppLink> _configServer;
        private readonly IUserAccessHandler _userAccess;

        public AppLinkController(IConfigServerManager<AppLink> configServer, IUserAccessHandler userAccess)
        {            
            _configServer = configServer;
            _userAccess = userAccess;
        }

        // GET api/applink
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "myapp001", "myapp002" };
        }

        // GET api/applink/myapp001
        [HttpGet("{appid}")]
        public string Get(string appid)
        {
            if (appid == null)
                throw new ArgumentNullException("appid");

            var user = _userAccess.GetUser();
            var appResource = new AppLink(appid);

            var data = _configServer.Retrieve(user, appResource);

            if (data == null)
                return "(null)";

            return data.ToString();
        }

        // GET applink/create?link=<>&location=<>
        [HttpGet("create")]
        public void Create([FromQuery]string link, [FromQuery]string location)
        {
            this.Post(link, location);
        }

        // POST api/applink/myapp001 (body=value)
        [HttpPost("{appid}")]
        public void Post([FromRoute]string appid, [FromBody]string value)
        {
            var user = _userAccess.GetUser();
            var appResource = new AppLink(appid);

            var appLocation = new AppResource(value, "dev");

            string targetLocation = appResourceLocation.Resolve(null, appLocation);

            var data = new StringData(targetLocation);

            _configServer.Create(user, appResource, data);
        }

        // PUT api/config/myapp001
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
