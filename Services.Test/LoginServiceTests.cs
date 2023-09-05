namespace Services.Test
{
    public class LoginServiceTests
    {
        [Test]
        public void ShouldBeAbleToLogin()
        {
            var staff = new Staff()
            {
                Name = "Student",
                Email = "Email",
                Password = "Password",
                Role = nameof(StaffRoleTypes.Teacher)
            };

            var mockAuthService = new Mock<IAuthService>();
            mockAuthService.Setup(x => x.GetJwtToken(It.IsAny<JwtParams>())).Returns("sometoken");
            var mockStaffRepo = new Mock<IStaffRepository>();
            mockStaffRepo.Setup(x => x.GetStaffByUserNameAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(staff);
            var mockUserContext = new Mock<IUserContext>();
            mockUserContext.Setup(x => x.CurrentUserId).Returns(1);
            var staffService = new StaffService(mockUserContext.Object, mockStaffRepo.Object);
            var loginService = new LoginService(mockAuthService.Object, mockStaffRepo.Object, mockUserContext.Object);
            var token = loginService.StaffLogin(new LoginContract() { UserName = "UserName", Password = "Password" });

            Assert.That(token, Is.Not.Null);
            Assert.That(token, Is.Not.Empty);
            Assert.Pass();
        }

        [Test]
        public void ShouldBeAbleToRenewToken()
        {
            var staff = new Staff()
            {
                Name = "Student",
                Email = "Email",
                Password = "Password",
                Role = nameof(StaffRoleTypes.Teacher)
            };
            var mockAuthService = new Mock<IAuthService>();
            mockAuthService.Setup(x => x.GetJwtToken(It.IsAny<JwtParams>())).Returns("sometoken");
            var mockStaffRepo = new Mock<IStaffRepository>();
            mockStaffRepo.Setup(x => x.GetStaffById(It.IsAny<long>())).Returns(staff);
            var mockUserContext = new Mock<IUserContext>();
            mockUserContext.Setup(x => x.CurrentUserId).Returns(1);
            var staffService = new StaffService(mockUserContext.Object, mockStaffRepo.Object);
            var loginService = new LoginService(mockAuthService.Object, mockStaffRepo.Object, mockUserContext.Object);
            var token = loginService.RenewToken();

            Assert.That(token, Is.Not.Null);
            Assert.That(token, Is.Not.Empty);
            Assert.Pass();
        }
    }
}
