using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Infra;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXConfig.Server.Controllers
{
    [Authorize]
    public class WebAppLinkController : Controller
    {
        private readonly IUserAccessHandler _userAccess;
        private readonly IConfigServerManager<AppLink> _configServer;
        private readonly IStorageManager _storageManager;
        private readonly ILocationManager<AppResource> _appResourceLocation;

        public WebAppLinkController(IConfigServerManager<AppLink> configServer, ILocationManager<AppResource> appResourceLocation, IStorageManager storageManager, IUserAccessHandler userAccess)
        {
            this._userAccess = userAccess;
            this._configServer = configServer;
            this._storageManager = storageManager;
            this._appResourceLocation = appResourceLocation;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Applink
        public string Show([FromQuery]string link)
        {
            var user = _userAccess.GetUser();
            var appResource = new AppLink(link);

            var data = _configServer.Retrieve(user, appResource);
            
            if (data == null)
                return "NotFound()";

            string container = data.ToString();

            var config = _storageManager.Read(user, container);

            return config.ToString();
        }

        // GET: Applink
        [HttpPost]
        public string Create([FromForm]string link, [FromForm]string location)
        {
            var user = _userAccess.GetUser();
            var appResource = new AppLink(link);

            var appLocation = new AppResource(location, "dev");

            string targetLocation = _appResourceLocation.Resolve(user, appLocation);

            var data = new StringData(targetLocation);

            _configServer.Create(user, appResource, data);

            return $"applink:{link}";
        }

        // GET: Applink
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

    }
}