namespace Windy.Shared.Security
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Azure.WebJobs.Host.Bindings;
    using Microsoft.IdentityModel.Tokens;

    public class AccessTokenValueProvider : IValueProvider
    {
        private const string AUTH_HEADER_NAME = "Authorization";
        private const string BEARER_PREFIX = "Bearer ";
        private HttpRequest _request;
        private readonly string _issuerToken;
        private readonly string _audience;
        private readonly string _issuer;

        public AccessTokenValueProvider(HttpRequest request, string issuerToken, string audience, string issuer)
        {
            _request = request;
            _issuerToken = issuerToken;
            _audience = audience;
            _issuer = issuer;
        }

        public Task<object> GetValueAsync()
        {
            if (_request.Headers.ContainsKey(AUTH_HEADER_NAME) &&
               _request.Headers[AUTH_HEADER_NAME].ToString().StartsWith(BEARER_PREFIX))
            {
                var token = _request.Headers["Authorization"].ToString().Substring(BEARER_PREFIX.Length);

                var tokenParams = new TokenValidationParameters()
                {
                    ValidAudience = _audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_issuerToken)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name" // JwtRegisteredClaimNames.UniqueName
                };

                var handler = new JwtSecurityTokenHandler();
                var result = handler.ValidateToken(token, tokenParams, out var securityToken);
                return Task.FromResult<object>(result);
            }
            else
            {
                throw new SecurityTokenException("No access token submitted.");
            }
        }

        public Type Type => typeof(ClaimsPrincipal);

        public string ToInvokeString() => string.Empty;
    }
}
