using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.DataAccess.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();

        int Add(Student student);

        Student GetById(int studentId);
        Student Update(Student student);
        void Delete(int studentId);
        IEnumerable<Grade> GetGrades(int studentId);
    }
}
