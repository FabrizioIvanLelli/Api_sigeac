using Microsoft.AspNetCore.Mvc;
using dao_library;
using entity_library;

namespace Api_sigeac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly StudentDAO _studentDAO;

        public StudentController(ILogger<StudentController> logger, StudentDAO studentDAO)
        {
            _logger = logger;
            _studentDAO = studentDAO;
        }
    

    [HttpGet]

    public List<Student> GetStudents()
        {
            return _studentDAO.ReadStudents();
        }

    [HttpPost]
    public ActionResult<Student> CreateStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest("Student data is required.");
            }
            if (_studentDAO.ReadStudentById(student.Id) != null)
            {
                return Conflict($"A student with ID {student.Id} already exists.");
            }

            var createdStudent = _studentDAO.CreateStudent(student);
            return StatusCode(201, createdStudent);
        }
    }


}
