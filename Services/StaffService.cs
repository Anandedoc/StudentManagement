namespace Services
{
    public interface IStaffService
    {
        void Create(StaffCreationContract detail);
    }

    public class StaffService : IStaffService
    {
        private readonly IUserContext _userContext;
        private readonly IStaffRepository _staffRepository;

        public StaffService(IUserContext userContext, IStaffRepository staffRepository)
        {
            _userContext = userContext;
            _staffRepository = staffRepository;
        }

        public void Create(StaffCreationContract detail)
        {
            if (_userContext.UserRole != nameof(StaffRoleTypes.Teacher))
            {
                throw new Exception("You are not having permission.");
            }

            Enum.TryParse(detail.Role, out StaffRoleTypes role);

            if (!(role is StaffRoleTypes.Teacher or StaffRoleTypes.Librarian or StaffRoleTypes.WatchMan))
            {
                throw new Exception("Invalid Staff Role Id");
            }
            var staff = new Staff()
            {
                Email = detail.Email,
                Name = detail.Name,
                Password = detail.Password,
                Role = nameof(role)
            };

            _staffRepository.Create(staff);

        }
    }
}
