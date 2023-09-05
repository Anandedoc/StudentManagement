using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public interface IAuthService
    {
        string GetJwtToken(JwtParams jwtParams);
    }

    public class AuthService : IAuthService
    {
        private readonly string _JWTSecret;
        private readonly long _JWTExpiryDays;

        public AuthService(IConfiguration configuration)
        {
            _JWTSecret = configuration.GetValue<string>("JWTSecret", string.Empty);
            _JWTExpiryDays = configuration.GetValue<long>("JWTExpiryDays", 2);

        }
        public string GetJwtToken(JwtParams jwtParams)
        {
            return JwtBuilder.Create().WithAlgorithm(new HMACSHA256Algorithm()).
                WithSecret(_JWTSecret)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddDays(_JWTExpiryDays).ToUnixTimeSeconds())
                .AddClaim("UserId", jwtParams.UserId)
                .AddClaim("Name", jwtParams.Name)
                .AddClaim("Role", jwtParams.Role)
                .AddClaim("Email", jwtParams.Email)
                .AddClaim("IssuedAt", DateTimeOffset.Now.ToUnixTimeMilliseconds())
                .Encode();
        }
    }
}
