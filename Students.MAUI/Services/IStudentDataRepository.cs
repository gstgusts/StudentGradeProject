using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.MAUI.Models;

namespace Students.MAUI.Services
{
    internal interface IStudentDataRepository
    {
        IEnumerable<Student> GetAll();
    }
}
