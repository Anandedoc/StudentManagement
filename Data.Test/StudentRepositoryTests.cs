namespace Data.Test
{
    public class StudentRepositoryTests
    {
        private Repository Repository;
        private IStudentRepository _studentRepository;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<Repository>()
                .UseInMemoryDatabase("StudentManagementDatabase").Options;

            Repository = new Repository(options);
            _studentRepository = new StudentRepository(Repository);


            var student = new Student()
            {
                Name = "Studentone",
                Age = 12,
                Grade = "1",
            };
            _studentRepository.CreateStudent(student);
        }

        [Test]
        public void ShouldBeAbleToCreateStudent()
        {
            var student = new Student()
            {
                Name = "Student",
                Age = 12,
                Grade = "1"
            };

            _studentRepository.CreateStudent(student);

            Assert.That(student.ID, Is.Not.Zero);
            Assert.Pass();
        }

        [Test]
        public void ShouldBeAbleToUpdateStudentById()
        {
            var student = new Student()
            {
                Name = "Student",
                Age = 12,
                Grade = "1"
            };

            _studentRepository.CreateStudent(student);
            var studentToBeUpdated = _studentRepository.GetStudentById(student.ID);
            studentToBeUpdated.Name = "UpdatedName";
            _studentRepository.Update(studentToBeUpdated);
            var studentAlreadyUpdated = _studentRepository.GetStudentById(student.ID);
            Assert.That(studentAlreadyUpdated.Name, Is.EqualTo("UpdatedName"));
            Assert.Pass();
        }

        [Test]
        public void ShouldBeAbleToDeleteStudent()
        {
            var studentToBeDeleted = _studentRepository.GetStudentById(1);
            _studentRepository.Delete(studentToBeDeleted);
            var studentAlreadyDeleted = _studentRepository.GetStudentById(1);

            Assert.That(studentAlreadyDeleted, Is.Null);
            Assert.Pass();
        }

        [Test]
        public void ShouldBeAbleToGetAllStudents()
        {
            var students = _studentRepository.GetAllStudents();

            Assert.That(students, Is.Not.Null);
            Assert.Pass();
        }
    }
}
