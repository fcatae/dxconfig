using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Infra
{
    public static class GithubAuthenticationDefaults
    {
        public const string AuthenticationScheme = "GitHub";
        public const string DisplayName = "GitHub";
        public const string AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
        public const string TokenEndpoint = "https://github.com/login/oauth/access_token";
        public const string UserInformationEndpoint = "https://api.github.com/user";
    }
}
