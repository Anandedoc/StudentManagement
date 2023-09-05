namespace Data.Test
{
    public class StaffRepositoryTests
    {
        private Repository Repository;
        private IStaffRepository _staffRepository;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<Repository>()
                .UseInMemoryDatabase("StudentManagementDatabase").Options;

            Repository = new Repository(options);
            _staffRepository = new StaffRepository(Repository);
        }

        [Test]
        public void ShouldBeAbleToCreateStafft()
        {
            var staff = new Staff()
            {
                Name = "Student",
                Email = "Email",
                Password = "Password",
                Role = nameof(StaffRoleTypes.Teacher)
            };

            _staffRepository.Create(staff);

            Assert.That(staff.ID, Is.Not.Zero);
            Assert.Pass();
        }
    }
}
