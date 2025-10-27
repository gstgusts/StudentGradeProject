using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Students.DataAccess
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public StudentDbContext()
        {
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(
        //    "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Temp\\StudentGradeProject\\Students.DataAccess\\StudentDb.mdf;Integrated Security=True");
    }
}
