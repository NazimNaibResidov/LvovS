using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace LvovS.WebUI.JWT
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key;

        private readonly Dictionary<string, string> users = new Dictionary<string, string>
        {
            {"user1","psw1" },
            {"user2","psw2" }
        };

        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }

        public string Authentication(string name, string password)
        {
            if (users.Any(x => x.Key == name && x.Value == password))
            {
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("bu menim string key");
            var tokeDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name,name)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokeDes);
            return tokenHandler.WriteToken(token);
        }
    }
}