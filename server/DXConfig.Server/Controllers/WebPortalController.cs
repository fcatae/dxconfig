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
using DXConfig.Server.Managers;
using Microsoft.AspNetCore.Http.Extensions;

namespace DXConfig.Server.Controllers
{
    [Authorize]
    public class WebPortalController : Controller
    {
        private readonly IUserAccessHandler _userAccess;
        private readonly IUserManager _userManager;

        public WebPortalController(IUserAccessHandler userAccess, IUserManager userManager)
        {
            this._userAccess = userAccess;
            this._userManager = userManager;
        }

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
        public async Task<ActionResult> RedirectToGithub()
        {
            // If user is not authenticated, then redirect to AuthProvider
            var authResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authResult.Succeeded || authResult.Ticket.Principal.Identity.IsAuthenticated == false)
            {
                // authenticate in git
                return Challenge(GithubAuthenticationDefaults.AuthenticationScheme);
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
        
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return View();
        }

        [Authorize]
        public string ClientIdentity()
        {
            var user = _userAccess.GetUser();

            string token = _userManager.ExportUser(user);

            string action = (string)nameof(ConfigController.Start);
            string controller = (string)nameof(ConfigController);

            //string url = Url.RouteUrl("portal", new { controller = "WebPortal", action = "index" }, "https", Request.Host.Value);

            string url = Url.RouteUrl("Config_Start", new { }, Request.Scheme, Request.Host.Value);

            return $"dxconfig login {token}@{url}";
        }
    }
}