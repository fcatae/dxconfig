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

        public WebAppLinkController(IConfigServerManager<AppLink> configServer, IStorageManager storageManager, IUserAccessHandler userAccess)
        {
            this._userAccess = userAccess;
            this._configServer = configServer;
            this._storageManager = storageManager;
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
        public string Create([FromQuery]string link)
        {
            return $"applink:{link}";
        }

    }
}