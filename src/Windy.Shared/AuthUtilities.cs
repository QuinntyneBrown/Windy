using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Windy.Shared.Security;

namespace Windy.Shared
{
    public static class AuthUtilities
    {
        private const string AUTH_HEADER_NAME = "Authorization";
        private const string BEARER_PREFIX = "Bearer ";
        
        public static ClaimsPrincipal ResolveClaimsPrincipal(HttpRequest httpRequest)
        {
            if (httpRequest.Headers.ContainsKey(AUTH_HEADER_NAME) &&
               httpRequest.Headers[AUTH_HEADER_NAME].ToString().StartsWith(BEARER_PREFIX))
            {
                var token = httpRequest.Headers["Authorization"].ToString().Substring(BEARER_PREFIX.Length);

                var tokenParams = new TokenValidationParameters()
                {
                    ValidAudience = Environment.GetEnvironmentVariable("Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("IssuerToken"))),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name" // JwtRegisteredClaimNames.UniqueName
                };

                var handler = new JwtSecurityTokenHandler();

                return handler.ValidateToken(token, tokenParams, out var securityToken);                
            }
            else
            {
                throw new SecurityTokenException("No access token submitted.");
            }
        }
    }
}
