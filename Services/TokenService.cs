using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TaskManager.Models;

namespace TaskManager.Services;

public class TokenService
{
    public string GerenerateToken(UserAccount user)
    {

        var tokenHander = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject =

                new ClaimsIdentity(new Claim[]
                {
                    new (ClaimTypes.Role , value : "admin"),
                    new  (ClaimTypes.Name, value : "LucasLantemamLeite"),
                    new ("fruta", value: "Banana"),
                }
            ),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials
            (
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var token = tokenHander.CreateToken(tokenDescription);
        return tokenHander.WriteToken(token);

    }
}