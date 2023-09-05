namespace Data.Repositories
{
    public interface IStudentRepository
    {
        void CreateStudent(Student user);
        void Delete(Student student);
        void Update(Student student);
        Student GetStudentById(long studentId);

        List<Student> GetAllStudents();
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly Repository _repository;

        public StudentRepository(Repository repository)
        {
            _repository = repository;
        }
        public void CreateStudent(Student student)
        {
            _repository.Students.Add(student);
            _repository.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            return _repository.Students.ToList();
        }

        public void Update(Student studnet)
        {
            _repository.Students.Update(studnet);
            _repository.SaveChanges();
        }

        public void Delete(Student studentToBeDeleted)
        {
            _repository.Remove(studentToBeDeleted);
            _repository.SaveChanges();
        }

        public Student GetStudentById(long studnetId)
        {
            return _repository.Students.FirstOrDefault(x => x.ID == studnetId);

        }
    }
}
