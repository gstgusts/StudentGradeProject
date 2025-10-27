using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.DataAccess;

namespace Students.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private StudentDbContext _db;

        public StudentsController()
        {
            _db = new StudentDbContext();
        }

        [HttpGet]
        public Student[] GetStudents()
        {
            var data = _db.Students.ToArray();
            return data;
        }
    }
}
