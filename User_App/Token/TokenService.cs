
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace User_App.Token
{
    public class TokenService : ITokenServie
    {

        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;

            _repository = userRepository;
        }

        public async Task<string> GetTokenByname(string userName)
        {

            var result = await _repository.GetUserByName(userName);
            if (result.Name.Length > 0)
            {
                throw new ArgumentException();
            }

            else
            {
                List<Claim> claims = new()
        {
            new Claim("UserName", userName)
        };
                string secretKey = _configuration.GetSection("AppSettings:Token").Value;

                SymmetricSecurityKey tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                SigningCredentials credentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256);
                SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
                    SigningCredentials = credentials,
                    Expires = DateTime.Now.AddDays(1)
                };

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken token = tokenHandler.CreateToken(descriptor);
                string tokenString = tokenHandler.WriteToken(token);
                return tokenString;
            }
        }
    }
}


