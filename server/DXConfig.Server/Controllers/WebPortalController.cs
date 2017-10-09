using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using DXConfig.Server.Infra;
using System.Security.Claims;

namespace DXConfig.Server.Controllers
{
    [Authorize]
    public class WebPortalController : Controller
    {
        // GET: Portal
        public async Task<ActionResult> Index()
        {
            var authResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            // show button to start authentication
            return View();
        }

        [AllowAnonymous]
        public async Task<ActionResult> Login([FromQuery]string returnUrl)
        {
            // If user is not authenticated, then redirect to AuthProvider
            var authResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // should always return failure
            if(!authResult.Succeeded || authResult.Ticket.Principal.Identity.IsAuthenticated == false )
            {
                return View();
            }

            // should not get up to here
            return View();
        }

        [AllowAnonymous]
        public async Task<ActionResult> RedirectToExternalLogin()
        {
            // If user is not authenticated, then redirect to AuthProvider
            var authResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authResult.Succeeded || authResult.Ticket.Principal.Identity.IsAuthenticated == false)
            {
                return RedirectToAction(nameof(SimulateExternalAuthentication));

                // authenticate in git
                // return Challenge(GithubAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<ActionResult> SimulateExternalAuthentication([FromQuery]string username)
        {
            if(username == null)
            {
                return View();
            }

            // receive a valid username
            // create a principal
            var principal = new ClaimsPrincipal(
                                new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.Name, username),
                                        new Claim(ClaimTypes.Role, "tester")
                                    }, "authtest"));

            // persist user authentication in the cookie
            await HttpContext.SignInAsync(principal);

            return RedirectToAction(nameof(Logged));
        }
        
        public ActionResult Logged([FromQuery]string username)
        {
            return View();
        }

        [Authorize]
        public ActionResult Admin([FromQuery]string username)
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