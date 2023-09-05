namespace Services.Test
{
    public class StudentServicesTest
    {
        [Test]
        public void ShouldCreateStudent()
        {
            var mockStudentRepo = new Mock<IStudentRepository>();
            var mockUserContext = new Mock<IUserContext>();
            mockUserContext.Setup(x => x.CurrentUserId).Returns(1);

            var student = new StudentCreationContract()
            {
                Name = "Student",
                Age = 12,
                Grade = "1"
            };

            var studentService = new StudentService(mockUserContext.Object, mockStudentRepo.Object);

            studentService.Create(student);
            Assert.Pass();
        }

        [Test]
        public void TeacherShouldDeleteStudent()
        {
            var student = new Student()
            {
                ID = 1,
                Name = "Student",
                Age = 12,
                Grade = "1"
            };
            var mockStudentRepo = new Mock<IStudentRepository>();
            mockStudentRepo.Setup(x => x.GetStudentById(It.IsAny<long>())).Returns(student);
            var mockUserContext = new Mock<IUserContext>();
            mockUserContext.Setup(x => x.CurrentUserId).Returns(1);
            mockUserContext.Setup(x => x.UserRole).Returns(nameof(StaffRoleTypes.Teacher));
            var studentService = new StudentService(mockUserContext.Object, mockStudentRepo.Object);

            studentService.Delete(1);

            Assert.Pass();
        }
        [Test]
        public void ThrowExceptionWhenNonTeacherDeleteStudent()
        {
            var student = new Student()
            {
                ID = 1,
                Name = "Student",
                Age = 12,
                Grade = "1"
            };
            var mockStudentRepo = new Mock<IStudentRepository>();
            mockStudentRepo.Setup(x => x.GetStudentById(It.IsAny<long>())).Returns(student);
            var mockUserContext = new Mock<IUserContext>();
            mockUserContext.Setup(x => x.CurrentUserId).Returns(1);
            mockUserContext.Setup(x => x.UserRole).Returns(nameof(StaffRoleTypes.Librarian));
            var studentService = new StudentService(mockUserContext.Object, mockStudentRepo.Object);

            Exception exception = Assert.Catch(() => studentService.Delete(1));

            Assert.NotNull(exception);
            Assert.IsInstanceOf<Exception>(exception);
            Assert.AreEqual("You are not having permission.", exception.Message);
        }

        [Test]
        public void ShouldGetAllStudents()
        {
            var studentOne = new Student()
            {
                Name = "StudentOne",
                Age = 12,
                Grade = "1"
            };

            var studentTwo = new Student()
            {
                Name = "StudentTwo",
                Age = 12,
                Grade = "1"
            };

            var students = new List<Student>() { studentOne, studentTwo };
            var mockUserContext = new Mock<IUserContext>();
            mockUserContext.Setup(x => x.CurrentUserId).Returns(1);
            var mockStudentRepository = new Mock<IStudentRepository>();
            mockStudentRepository.Setup(repo => repo.GetAllStudents()).Returns(students);

            var studentService = new StudentService(mockUserContext.Object, mockStudentRepository.Object);

            var studentsFromService = studentService.GetAllStudents();
            Assert.That(studentsFromService, Is.Not.Null);
            Assert.That(studentsFromService, Is.Not.Empty);

            Assert.Pass();
        }
    }
}
