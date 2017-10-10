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
    public class ConfigController : Controller
    {
        //ConfigurationManager _configMgr;
        private readonly IConfigServerManager<AppResource> _configSrv;
        private readonly IUserAccessHandler _userAccess;

        public ConfigController(IConfigServerManager<AppResource> configSrv, IUserAccessHandler userAccess)
        {
            //_configMgr = (ConfigurationManager)configMgr;
            _configSrv = configSrv;
            _userAccess = userAccess;
        }

        // GET api/values
        [HttpGet(Name="Config_Start")]
        public IEnumerable<string> Start()
        {
            return new string[] { "myapp001", "myapp002" };
        }

        // GET api/config/myapp001
        [HttpGet("{appid}")]
        public string Get(string appid)
        {
            if (appid == null)
                throw new ArgumentNullException("appid");

            var user = _userAccess.GetUser();
            var resource = new AppResource(appid, "dev");

            var data = _configSrv.Retrieve(user, resource);

            if (data == null)
                return "(null)";

            return data.ToString();
        }

        // POST api/config/myapp001
        [HttpPost("{appid}")]
        public void Post([FromRoute]string appid, [FromBody]string value)
        {
            var user = _userAccess.GetUser();
            var resource = new AppResource(appid, "dev");

            _configSrv.Create(user, resource, new StringData(value));
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
