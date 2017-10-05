using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXConfig.Server.Controllers
{
    [Route("api/[controller]")]
    public class LocatorController : Controller
    {
        // GET api/locator/myapplication?env=test
        [HttpGet("{appid}")]
        public string Get(string appid, [FromQuery]string env)
        {
            string optEnvironment = env;

            if (appid == null)
                throw new ArgumentNullException("appid");

            string appToken = appid;

            if( optEnvironment != null )
            {
                appToken = $"{appid}/{optEnvironment}";
            }

            return appToken;
        }
    }
}