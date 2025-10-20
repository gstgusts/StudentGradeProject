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

            //var results = db.Students
            //    .Include(s => s.Grades);
            //    //.Where(s => s.Name == "Gusts");

            //System.Console.WriteLine(results.Count());

            //foreach (var student in results)
            //{
            //    System.Console.WriteLine($"{student.Name}-{student.Code}");

            //    foreach (var studentGrade in student.Grades)
            //    {
            //        System.Console.WriteLine($"{studentGrade.Subject}:{studentGrade.Value}");
            //    }
            //}

            //var student = new Student
            //{
            //    Code = "003",
            //    Name = "Anna",
            //    Surname = "Ozola"
            //};

            //var student2 = new Student
            //{
            //    Code = "004",
            //    Name = "Marta",
            //    Surname = "Zāle",
            //    Grades =
            //    [
            //        new Grade
            //        {
            //            Subject = "Matemātika",
            //            Date = DateTime.Now
            //        },
            //        new Grade
            //        {
            //            Subject = "Fizika",
            //            Date = DateTime.Now
            //        }
            //    ]
            //};

            ////db.Students.Add(student);
            ////db.Students.Add(student2);

            //db.Students.AddRange([student, student2]);

            //var result = db.Students.FirstOrDefault(s => s.Name == "Gusts");

            //if (result != null)
            //{
            //    result.Surname = "Linkevičs";
            //}

            //db.SaveChanges();

            //var groupedResults = db.Students.GroupBy(s => s.Surname.Substring(0, 1));

            //foreach (var groupedResult in groupedResults)
            //{
            //    System.Console.WriteLine(groupedResult.Key);

            //    foreach (var student in groupedResult)
            //    {
            //        System.Console.WriteLine(student.Surname);
            //    }
            //}

        }
    }
}
