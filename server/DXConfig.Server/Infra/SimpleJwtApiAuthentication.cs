using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DXConfig.Server.Infra
{
    public class SimpleJwtApiAuthenticationOptions : AuthenticationSchemeOptions
    {
    }

    public class SimpleJwtApiAuthentication : AuthenticationHandler<SimpleJwtApiAuthenticationOptions>
    {
        public SimpleJwtApiAuthentication(IOptionsMonitor<SimpleJwtApiAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var result = AuthenticateResult.NoResult();

            if (Request.Headers.Keys.Contains("Authorization"))
            {
                StringValues bearerToken;
                var authHeader = Request.Headers.TryGetValue("Authorization", out bearerToken);

                string token = bearerToken.ToString().Replace("Bearer ", "", StringComparison.CurrentCultureIgnoreCase).Trim();
                
                var claims = new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, "jwttoken"),
                    new Claim(ClaimTypes.Name, "jwttoken"),
                    new Claim("urn:dxconfig:token" , token)};

                var identity = new ClaimsIdentity(claims, "jwt");
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, "jwt");

                result = AuthenticateResult.Success(ticket);
            }

            return Task.FromResult(result);
        }
    }
}
