using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DXConfig.Server.Pages
{
    public class AuthPageModel : PageModel
    {
        public string Message { get; set; }

        public async Task OnGetAsync()
        {
            var result = await HttpContext.AuthenticateAsync("qswhat");

            var ident = result.Principal.Identity as ClaimsIdentity;
            
            Message = "Your application description page.";
        }
    }
}