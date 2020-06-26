using Invoices.Data.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Invoices.Services.Indentity.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly ApplicationSettings appSettings;

        public TokenService(IOptions<ApplicationSettings> appSettings)
            => this.appSettings = appSettings.Value;

        public string GenerateToken(User user)
        {
            var claims = GenerateClaims(user);
            var tokenDescriptor = GetTokenDescriptor(claims);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new[]
            //    {
            //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //        new Claim(ClaimTypes.Name, user.Email)
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(
            //        new SymmetricSecurityKey(key),
            //        SecurityAlgorithms.HmacSha256Signature)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);

            return encryptedToken;
        }

        private SecurityTokenDescriptor GetTokenDescriptor(Claim[] claims)
        {
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);

            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(appSettings.TokenExpireInMinutes),
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
