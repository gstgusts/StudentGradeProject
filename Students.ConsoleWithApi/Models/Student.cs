using System.ComponentModel.DataAnnotations;

namespace Students.ConsoleWithApi.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Code { get; set; }
    }
}
