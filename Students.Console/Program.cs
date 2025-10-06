using Microsoft.EntityFrameworkCore;
using Students.DataAccess;

namespace Students.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new StudentDbContext();

            db.Database.EnsureCreated();

            var results = db.Students
                .Include(s => s.Grades)
                .Where(s => s.Name == "Gusts");

            System.Console.WriteLine(results.Count());

            foreach (var student in results)
            {
                System.Console.WriteLine($"{student.Name}-{student.Code}");

                foreach (var studentGrade in student.Grades)
                {
                    System.Console.WriteLine($"{studentGrade.Subject}:{studentGrade.Value}");
                }
            }
        }
    }
}
