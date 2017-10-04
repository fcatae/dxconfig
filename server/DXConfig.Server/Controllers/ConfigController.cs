using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;
using DXConfig.Server.Managers;
using Microsoft.AspNetCore.Mvc;

namespace DXConfig.Server.Controllers
{
    [Route("api/[controller]")]
    public class ConfigController : Controller
    {
        ConfigurationManager _configMgr;

        public ConfigController(IConfigurationManager configMgr)
        {
            _configMgr = (ConfigurationManager)configMgr;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "myapp001", "myapp002" };
        }

        // GET api/config/myapp001
        [HttpGet("{appid}")]
        public string Get(string appid)
        {
            if (appid == null)
                throw new ArgumentNullException("appid");

            return _configMgr.Retrieve(appid, "prod");
        }

        // POST api/config/myapp001
        [HttpPost("{appid}")]
        public void Post([FromRoute]string appid, [FromBody]string value)
        {
            _configMgr.Create(appid, "prod", value);
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
