namespace StudentManagement.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(LoginContract detail)
        {
            try
            {
                var token = _loginService.StaffLogin(detail);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("/Renew")]
        public IActionResult Renew()
        {
            try
            {
                var token = _loginService.RenewToken();
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
