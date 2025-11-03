using Microsoft.EntityFrameworkCore;
using Students.DataAccess.Interfaces;

namespace Students.DataAccess.Services
{
    public class StudentRepositoryService : IStudentRepository
    {
        private readonly StudentDbContext _db;
        public StudentRepositoryService(StudentDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }
        public IEnumerable<Student> GetAll()
        {
            return _db.Students.ToList();
        }

        public int Add(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();

            return student.Id;
        }

        public Student GetById(int studentId)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new ArgumentException("Student not found");
            }

            return student;
        }

        public Student Update(Student student)
        {
            var existingStudent = _db.Students.FirstOrDefault(s => s.Id == student.Id);

            if (existingStudent == null)
            {
                throw new ArgumentException("Student not found");
            }

            existingStudent.Name = student.Name;
            existingStudent.Surname = student.Surname;
            existingStudent.Code = student.Code;

            _db.SaveChanges();

            return existingStudent;
        }

        public void Delete(int studentId)
        {
            var existingStudent = _db.Students.FirstOrDefault(s => s.Id == studentId);
            if (existingStudent == null)
            {
                throw new ArgumentException("Student not found");
            }

            _db.Students.Remove(existingStudent);
            _db.SaveChanges();
        }

        public IEnumerable<Grade> GetGrades(int studentId)
        {
            var student = _db.Students.Include(s => s.Grades).FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new ArgumentException("Student not found");
            }

            return student.Grades.ToArray();

        }
    }
}
