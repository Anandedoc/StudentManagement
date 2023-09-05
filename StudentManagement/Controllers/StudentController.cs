using Data.Domain;

namespace StudentManagement.Controllers
{
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studnetServices)
        {
            _studentService = studnetServices;

        }

        [HttpGet]
        [Route("/Students")]
        public IActionResult GetAllStudents()
        {
            try
            {
                var result = _studentService.GetAllStudents();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("/Students")]
        public IActionResult Create(StudentCreationContract details)
        {
            try
            {
                _studentService.Create(details);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("/Students")]
        public IActionResult Update(Student student)
        {
            try
            {
                _studentService.Update(student);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete]
        [Route("/Students")]
        public IActionResult Delete(long studentId)
        {
            try
            {
                _studentService.Delete(studentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
