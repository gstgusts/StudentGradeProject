using System.ComponentModel.DataAnnotations;

namespace Students.DataAccess
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public List<Grade> Grades { get; set; } = new();
    }
}
