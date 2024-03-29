using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Novell.Directory.Ldap;

namespace Authorization.Samples.Authentication
{
    public static class AuthenticationExtensions
    {
        public static AuthenticationBuilder AddLdap(this AuthenticationBuilder builder)
        {
            builder.Services.AddScoped<ILdapConnection, LdapConnection>();

            return builder.AddScheme<LdapAuthenticationOptions, LdapAuthenticationHandler>(
                AuthenticationSchemes.Ldap,
                _ => { });
        }

        public static AuthenticationBuilder AddCustomJwtToken(this AuthenticationBuilder builder)
        {
            return builder.AddScheme<JwtSchemeOptions, JwtSchemeHandler>(
                AuthenticationSchemes.AppJwt,
                _ => { });
        }
    }
}