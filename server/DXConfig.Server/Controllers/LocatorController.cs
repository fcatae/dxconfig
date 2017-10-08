using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Infra;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXConfig.Server.Controllers
{
    [Route("api/[controller]")]
    public class LocatorController : Controller
    {
        private readonly IUserAccessHandler _userAccessHandler;
        private readonly ILocationManager<AppResource> _locationManager;

        public LocatorController(ILocationManager<AppResource> locationManager, IUserAccessHandler userAccessHandler)
        {
            _userAccessHandler = userAccessHandler;
            _locationManager = locationManager;
        }

        // GET api/locator/myapplication?env=test
        [HttpGet("{appid}")]
        public string Get(string appid, [FromQuery]string env)
        {
            if (appid == null)
                throw new ArgumentNullException("appid");

            var user = _userAccessHandler.GetUser();
            var resource = new AppResource(appid, env ?? "dev");

            string appToken = _locationManager.Resolve(user, resource);

            return appToken;
        }
    }
}