using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DXConfig.Server.Infra
{
    public class QueryStringAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        string _qsAuthUser = "authuser";
        string _qsSecret = "secret";

        public QueryStringAuthenticationMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var query = context.Request.Query;
            string username = null;
            string secret = null;

            if (query.ContainsKey(_qsAuthUser))
            {
                username = query[_qsAuthUser];
            }

            if (query.ContainsKey(_qsSecret))
            {
                secret = query[_qsSecret];
            }

            if( username != null || secret != null )
            {
                AddIdentity(context, username, secret);
            }

            return this._next(context);
        }

        void AddIdentity(HttpContext context, string username, string secret)
        {
            var identity = new ClaimsIdentity("querystring");

            if (username != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
                identity.AddClaim(new Claim(ClaimTypes.Name, username));
            }

            if(secret != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.UserData, secret));
            }            

            if (context.User == null || (!context.User.Identity.IsAuthenticated) )
            {
                context.User = new ClaimsPrincipal();
            }

            context.User.AddIdentity(identity);
        }
    }
}
