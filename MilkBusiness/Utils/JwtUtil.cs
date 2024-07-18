using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MilkData;
using MilkData.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness.Utils
{
    public class JwtUtil
    {
        public static string GenerateJwtToken(Account account)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var key = config["Jwt:Key"];
            var issuer = config["Jwt:Issuer"];
            var audience = config["Jwt:Audience"];

            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, account.AccountId.ToString()),
                new Claim("FullName", account.FullName),
                new Claim("Email", account.Email),
                new Claim("Password", account.Password),
                new Claim(ClaimTypes.Role, account.Role),
                new Claim("Address", account.Address),
                new Claim("Phone", account.Phone),
            };

            //Add expiredTime of token
            var expires = DateTime.Now.AddMinutes(30);

            //Create token
            var token = new JwtSecurityToken(issuer, audience, claims, notBefore: DateTime.Now, expires, credentials);
            return jwtHandler.WriteToken(token);
        }
    }
}
