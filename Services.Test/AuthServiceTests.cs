using Microsoft.Extensions.Configuration;

namespace Services.Test
{
    public class AuthServiceTests
    {
        [Test]
        public void ShouldGetJwtToken()
        {
            var configuration = new ConfigurationBuilder()
                        .AddInMemoryCollection(new[]
                        {
                new KeyValuePair<string, string>("JWTSecret", "StudentManagement"),
                new KeyValuePair<string, string>("JWTExpiryDays","2")
                        })
                        .Build();
            var _authService = new AuthService(configuration);

            var jwtParams = new JwtParams()
            {
                Email = "Email",
                Name = "Name",
                Role = nameof(StaffRoleTypes.Teacher),
                UserId = 1
            };

            var token = _authService.GetJwtToken(jwtParams);
            Assert.That(token, Is.Not.Null);
            Assert.That(token, Is.Not.Empty);
            Assert.Pass();
        }
    }
}
