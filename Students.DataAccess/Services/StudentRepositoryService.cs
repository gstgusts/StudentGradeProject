using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.DataAccess.Interfaces;

namespace Students.DataAccess.Services
{
    public class StudentRepositoryService : IStudentRepository
    {
        private StudentDbContext _db;
        public StudentRepositoryService(StudentDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }
        public IEnumerable<Student> GetAll()
        {
            return _db.Students.ToList();
        }

        public void Add(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
        }
    }
}
