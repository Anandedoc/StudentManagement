namespace Services
{
    public interface IStudentService
    {
        void Create(StudentCreationContract detail);
        void Update(Student detail);
        void Delete(long studentId);
        List<Student> GetAllStudents();
    }

    public class StudentService : IStudentService
    {
        private readonly IUserContext _userContext;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IUserContext userContext, IStudentRepository studentRepository)
        {
            _userContext = userContext;
            _studentRepository = studentRepository;
        }


        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }
        public void Create(StudentCreationContract detail)
        {
            var student = new Student()
            {
                Age = detail.Age,
                Grade = detail.Grade,
                Name = detail.Name
            };

            _studentRepository.CreateStudent(student);
        }

        public void Update(Student detail)
        {
            if (_userContext.UserRole != nameof(StaffRoleTypes.Teacher))
            {
                throw new Exception("You are not having permission.");
            }

            _studentRepository.Update(detail);
        }

        public void Delete(long studentId)
        {
            if (_userContext.UserRole != nameof(StaffRoleTypes.Teacher))
            {
                throw new Exception("You are not having permission.");
            }

            var studentToBeDeleted = _studentRepository.GetStudentById(studentId);
            if (studentToBeDeleted is null)
            {
                throw new Exception("Invalid Student Id");
            }

            _studentRepository.Delete(studentToBeDeleted);
        }
    }
}
