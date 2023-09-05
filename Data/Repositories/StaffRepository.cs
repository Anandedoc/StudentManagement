namespace Data.Repositories
{
    public interface IStaffRepository
    {
        long Create(Staff staff);
        Staff? GetStaffByUserNameAndPassword(string email, string password);
        Staff? GetStaffById(long id);

    }

    public class StaffRepository : IStaffRepository
    {
        private readonly Repository _repository;

        public StaffRepository(Repository repository)
        {
            _repository = repository;
        }

        public long Create(Staff staff)
        {
            _repository.Staffs.Add(staff);
            _repository.SaveChanges();
            return staff.ID;
        }

        public Staff? GetStaffByUserNameAndPassword(string email, string password)
        {
            return _repository.Staffs.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
        public Staff? GetStaffById(long staffId)
        {
            return _repository.Staffs.FirstOrDefault(x => x.ID == staffId);
        }
    }
}
