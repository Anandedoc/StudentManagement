namespace StudentManagement.Test
{
    public class StaffControllerTest
    {
        [Test]
        public void ShouldCreateStaff()
        {
            var staff = new StaffCreationContract()
            {
                Name = "Staff",
                Email = "Email",
                Password = "Password",
                Role = nameof(StaffRoleTypes.Teacher),
                
            };

            var mockStaffService = new Mock<IStaffService>();

            mockStaffService.Setup(service => service.Create(staff));

            var staffController = new StaffController(mockStaffService.Object);

            var result = staffController.Create(staff);

            Assert.IsInstanceOf<OkResult>(result);
            Assert.Pass();
        }
    }
}
