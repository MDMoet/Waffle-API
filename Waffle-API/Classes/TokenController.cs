using Azure;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Waffle_API.Classes
{
    public class TokenController
    {
        public static void CreateToken(string username)
        {
            var claims = new[]
            {
               new Claim(ClaimTypes.Name, username),
               new Claim(ClaimTypes.Role, "User")
            };
            FinializedToken(claims);
        }
        private static void FinializedToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKey"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
