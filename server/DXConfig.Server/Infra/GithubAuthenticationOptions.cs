using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace DXConfig.Server.Infra
{
    public class GithubAuthenticationOptions : OAuthOptions
    {
        public GithubAuthenticationOptions()
        {
            CallbackPath = new PathString("/signin-github");
            AuthorizationEndpoint = GithubAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = GithubAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = GithubAuthenticationDefaults.UserInformationEndpoint;
            SaveTokens = true;

            Scope.Add("user:email");

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "login");
            ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
            ClaimActions.MapJsonKey(ClaimTypes.Webpage, "html_url");
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email");         
            ClaimActions.MapJsonKey("picture", "avatar_url");
        }

    }
}
