using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DXConfig.Server.Pages
{
    public class LoginModel : PageModel
    {
        public string Message { get; set; }
        
        public async Task OnGetAsync()
        {
            string username = "fabricio";

            // Create the identity from the user info
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
            identity.AddClaim(new Claim(ClaimTypes.Name, username));

            // Authenticate using the identity
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(  "dxConfigCookieAuthScheme", //CookieAuthenticationDefaults.AuthenticationScheme, 
                                            principal, 
                                            new AuthenticationProperties { IsPersistent = false }
                                            );

            Message = "Your application description page.";
        }
    }
}