using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXConfig.Server.Controllers
{
    public class WebPortalController : Controller
    {
        // GET: Portal
        public ActionResult Index()
        {
            return View();
        }

        // GET: Portal/Details
        public ActionResult Details(int id)
        {
            return View();
        }        
    }
}