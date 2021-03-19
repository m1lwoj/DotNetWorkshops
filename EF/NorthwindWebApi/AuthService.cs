using Castle.Core.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NorthwindWebApi
{
    public class AuthService : IAuthService
    {
        private AuthTokenSettings _settings;
        private ILogger<AuthService> _logger;

        public AuthService(AuthTokenSettings settings, ILogger<AuthService> logger)
        {
            _settings = settings;
            _logger = logger;
        }

        public string GenerateSecurityToken(string email, string password)
        {
            _logger.Log(LogLevel.Information, "aaaaa");
            if (!Authenticate(email, password))
            {
                throw new Exception("Not authorized user");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, "user")
            };

            if (IsAdmin(email))
            {
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _settings.Issuer,
                Audience = _settings.Audience,
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_settings.ExpDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public bool Authenticate(string login, string password) =>
            (login == "test1@test.com" && password == "password1") ||
            (login == "test2@test.com" && password == "password2");

        private bool IsAdmin(string login) => login == "test1@test.com";
    }
}
