using Invoices.Identity.Database.Entities;
using Invoices.Shared;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Invoices.Identity.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly ApplicationSettings applicationSettings;

        public TokenService(IOptions<ApplicationSettings> applicationSettings)
            => this.applicationSettings = applicationSettings.Value;

        public string Generate(User user)
        {
            var claims = GenerateClaims(user);
            var tokenDescriptor = GetTokenDescriptor(claims);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }

        private SecurityTokenDescriptor GetTokenDescriptor(Claim[] claims)
        {
            var key = Encoding.ASCII.GetBytes(this.applicationSettings.Secret);

            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(this.applicationSettings.TokenExpireInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
        }

        private Claim[] GenerateClaims(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            if (user.RoleUsers.Count > 0)
            {
                IEnumerable<Claim> roleClaims = user.RoleUsers.Select(x => new Claim(ClaimTypes.Role, x.Role.Name));

                claims.AddRange(roleClaims);
            }

            return claims.ToArray();
        }
    }
}
