namespace Services
{
    public interface ILoginService
    {
        string StaffLogin(LoginContract detail);
        string RenewToken();

    }

    public class LoginService : ILoginService
    {
        private readonly IAuthService _authService;
        private readonly IStaffRepository _staffRepository;
        private readonly IUserContext _userContext;

        public LoginService(IAuthService authService, IStaffRepository staffRepository, IUserContext userContext)
        {
            _authService = authService;
            _staffRepository = staffRepository;
            _userContext = userContext;
        }

        public string StaffLogin(LoginContract detail)
        {

            var staff = _staffRepository.GetStaffByUserNameAndPassword(detail.UserName, detail.Password);

            if (staff is null)
            {
                throw new Exception("Invalid username or password");
            }

            var jwtParams = new JwtParams()
            {
                Email = staff.Email,
                Name = staff.Name,
                UserId = staff.ID,
                Role = staff.Role
            };

            var token = _authService.GetJwtToken(jwtParams);
            return token;
        }

        public string RenewToken()
        {
            var staff = _staffRepository.GetStaffById(_userContext.CurrentUserId);

            if (staff is null)
            {
                throw new Exception("Invalid username or password");
            }

            var jwtParams = new JwtParams()
            {
                Email = staff.Email,
                Name = staff.Name,
                UserId = staff.ID,
                Role = staff.Role
            };

            var token = _authService.GetJwtToken(jwtParams);
            return token;
        }
    }
}
