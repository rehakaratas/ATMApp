using ATMApp.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Application.Services.TokenService
{
    public class TokenHandler : ITokenHandler
    {
        public readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var expiry = DateTime.Now.AddDays(1);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.EmailAddress),
                new Claim(ClaimTypes.UserData,user.Id.ToString())
            };

            var token = new JwtSecurityToken(_configuration["Token:Issuer"], _configuration["Token:Audience"], claims, null, expiry, signingCredentials);

            Token userToken = new Token();
            userToken.AccessToken = tokenHandler.WriteToken(token);

            userToken.RefreshToken = CreateRefreshToken();

            return userToken;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using(RandomNumberGenerator random = RandomNumberGenerator.Create()) 
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
