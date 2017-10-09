using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXConfig.Server.Controllers
{
    [Route("applink")]
    public class WebAppLinkController : Controller
    {
        // GET: Applink
        [HttpGet("{id}")]
        public string Details(string id)
        {
            return $"applink:{id}";
        }
    }
}