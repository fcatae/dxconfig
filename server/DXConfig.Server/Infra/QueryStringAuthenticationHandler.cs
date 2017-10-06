using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DXConfig.Server.Infra
{
    public class QueryAuthOptions : AuthenticationSchemeOptions
    {        
    }

    public class QueryStringAuthenticationHandler : AuthenticationHandler<QueryAuthOptions>
    {
        const string QUERYSTRING_USER = "authuser";

        public QueryStringAuthenticationHandler(IOptionsMonitor<QueryAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var result = AuthenticateResult.NoResult();

            if (Request.Query.ContainsKey(QUERYSTRING_USER))
            {
                string username = Request.Query[QUERYSTRING_USER];

                // Create the identity from the user info
                var identity = new ClaimsIdentity("query");
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
                identity.AddClaim(new Claim(ClaimTypes.Name, username));

                // Authenticate using the identity
                var principal = new ClaimsPrincipal(identity);

                var ticket = new AuthenticationTicket(principal, this.Scheme.Name);

                result = AuthenticateResult.Success(ticket);
            }

            return Task.FromResult(result);
        }
    }
}
