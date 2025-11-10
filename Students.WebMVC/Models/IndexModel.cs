using Students.DataAccess;

namespace Students.WebMVC.Models
{
    public class IndexModel
    {
        public string Greeting { get; set; }

        public Student[] Students { get; set; }
    }
}
