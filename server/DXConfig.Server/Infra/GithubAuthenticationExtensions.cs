using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Infra;
using Microsoft.AspNetCore.Authentication;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GithubAuthenticationExtensions
    {
        public static AuthenticationBuilder AddGithub(this AuthenticationBuilder builder)
            => builder.AddGithub(GithubAuthenticationDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddGithub(this AuthenticationBuilder builder, Action<GithubAuthenticationOptions> configureOptions)
            => builder.AddGithub(GithubAuthenticationDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddGithub(this AuthenticationBuilder builder, string authenticationScheme, Action<GithubAuthenticationOptions> configureOptions)
            => builder.AddGithub(authenticationScheme, GithubAuthenticationDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddGithub(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<GithubAuthenticationOptions> configureOptions)
            => builder.AddOAuth<GithubAuthenticationOptions, GithubAuthenticationHandler>(authenticationScheme, displayName, configureOptions);
    }
}
