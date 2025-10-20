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

        void Add(Student student);
    }
}
