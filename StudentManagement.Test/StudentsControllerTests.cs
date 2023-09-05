using Data.Domain;

namespace StudentManagement.Test
{
    public class StudentsControllerTests
    {
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

            var mockStudentService = new Mock<IStudentService>();
            mockStudentService.Setup(service => service.GetAllStudents()).Returns(students);

            var studentController = new StudentController(mockStudentService.Object);

            var studetns = studentController.GetAllStudents();

            Assert.IsInstanceOf<OkObjectResult>(studetns);
            Assert.That(students, Is.Not.Null);
            Assert.That(students, Is.Not.Empty);
            Assert.Pass();
        }

        [Test]
        public void ShouldCreateStudent()
        {
            var student = new StudentCreationContract()
            {
                Name = "Student",
                Age = 12,
                Grade = "1"
            };

            var mockStudentService = new Mock<IStudentService>();

            mockStudentService.Setup(service => service.Create(student));

            var studentController = new StudentController(mockStudentService.Object);

            var result = studentController.Create(student);

            Assert.IsInstanceOf<OkResult>(result);
            Assert.Pass();
        }

        [Test]
        public void ShouldUpdateStudent()
        {
            var student = new Student()
            {
                ID = 1,
                Name = "Student",
                Age = 12,
                Grade = "1",
            };

            var mockStudentService = new Mock<IStudentService>();

            mockStudentService.Setup(service => service.Update(student));

            var studentController = new StudentController(mockStudentService.Object);

            var result = studentController.Update(student);

            Assert.IsInstanceOf<OkResult>(result);
            Assert.Pass();
        }

        [Test]
        public void ShouldDeleteStudent()
        {
            var mockStudentService = new Mock<IStudentService>();

            mockStudentService.Setup(service => service.Delete(It.IsAny<long>()));

            var studentController = new StudentController(mockStudentService.Object);

            var result = studentController.Delete(1);

            Assert.IsInstanceOf<OkResult>(result);
            Assert.Pass();
        }

        [Test]
        public void ShouldThrowExceptionWhenNonTeacherDeleteStudent()
        {
            var mockStudentService = new Mock<IStudentService>();

            mockStudentService.Setup(service => service.Delete(It.IsAny<long>())).Throws(new Exception("You are not having permission."));

            var studentController = new StudentController(mockStudentService.Object);

            var result = studentController.Delete(1);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            Assert.Pass();
        }
    }
}
