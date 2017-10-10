using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXConfig.Server.Controllers
{
    [Authorize]
    public class WebAppLinkController : Controller
    {
        private readonly IUserAccessHandler _userAccess;

        public WebAppLinkController(IUserAccessHandler userAccess)
        {
            this._userAccess = userAccess;
        }

        // GET: Applink
        public string Show([FromQuery]string link)
        {
            var user = _userAccess.GetUser();
            
            return $"applink:{user.Name},{link}";
        }

        // GET: Applink
        public string Create([FromQuery]string link)
        {
            return $"applink:{link}";
        }

    }
}