using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.DataAccess;

namespace Students.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext _db;

        public StudentsController(StudentDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public Student[] GetStudents()
        {
            var data = _db.Students.ToArray();
            return data;
        }
    }
}
