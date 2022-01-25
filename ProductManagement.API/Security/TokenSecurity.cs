using Microsoft.IdentityModel.Tokens;
using ProductManagement.Api;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagement.Security
{
    public class TokenSecurity
    {

        public static string GenerateToken(string email, string role)
        {
           

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),    
                    new Claim(ClaimTypes.Role, role),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new (new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
