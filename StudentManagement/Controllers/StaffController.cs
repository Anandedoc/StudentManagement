namespace StudentManagement.Controllers
{
    [ApiController]
    [Authorize]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [HttpPost]
        [Route("/Staff")]
        public IActionResult Create(StaffCreationContract details)
        {
            try
            {
                _staffService.Create(details);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
