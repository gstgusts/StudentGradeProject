using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.DataAccess;
using Students.DataAccess.Interfaces;

namespace Students.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repo;

        public StudentsController(IStudentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public Student[] GetStudents()
        {
            var data = _repo.GetAll();
            return data.ToArray();
        }

        [HttpGet]
        [Route("{studentId}")]
        public IActionResult GetStudent(int studentId)
        {
            try
            {
                var student = _repo.GetById(studentId);
                return Ok(student);
            }
            catch(ArgumentException ae)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{studentId}/Grades")]
        public IActionResult GetGrades(int studentId)
        {
            try
            {
                var grades = _repo.GetGrades(studentId);
                return Ok(grades);
            }
            catch (ArgumentException ae)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
           var id = _repo.Add(student);
           return Created($"api/Students/{id}", id);
        }

        [HttpPut]
        [Route("{studentId}")]
        public IActionResult PutStudent(Student student, int studentId)
        {
            if (student.Id != studentId)
            {
                return BadRequest();
            }

            try
            {
                var st = _repo.Update(student);
                return Ok(st);
            }
            catch (ArgumentException e)
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("{studentId}")]
        public IActionResult DeleteStudent(int studentId)
        {
            try
            {
                _repo.Delete(studentId);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound();
            }
        }
    }
}
