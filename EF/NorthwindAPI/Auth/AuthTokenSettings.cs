using Microsoft.Extensions.Configuration;

namespace NorthwindAPI.Auth
{
    public class AuthTokenSettings
    {
        public string Secret { get; }
        public string ExpDate { get; }
        public string Audience { get; }
        public string Issuer { get; }

        public AuthTokenSettings(IConfiguration config)
        {
            var section = config.GetSection("JwtConfig");
            Secret = section.GetValue<string>("secret");
            ExpDate = section.GetValue<string>("expirationInMinutes");
            Audience = section.GetValue<string>("audience");
            Issuer = section.GetValue<string>("issuer");
        }
    }
}
