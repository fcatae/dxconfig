using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXConfig.Server.Controllers
{
    [Route("api/[controller]")]
    public class LocatorController : Controller
    {
        ILocatorManager _locator;

        public LocatorController(ILocatorManager locator)
        {
            _locator = locator;
        }

        // GET api/locator/myapplication?env=test
        [HttpGet("{appid}")]
        public string Get(string appid, [FromQuery]string env, [FromQuery]string authUser)
        {
            if (appid == null)
                throw new ArgumentNullException("appid");

            string appToken = _locator.Find(appid, env);
            
            if( appToken == null )
            {
                appToken = _locator.SecureFind(authUser, appid, env);
            }

            return appToken;
        }
    }
}