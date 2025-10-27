using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Students.DataAccess;
using Students.DataAccess.Interfaces;
using Students.DataAccess.Services;

namespace Students.Web1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IStudentRepository _studentRepository;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _studentRepository = new StudentRepositoryService(new StudentDbContext());
        }

        public string TestValue { get; set; }

        public Student[] Students { get; set; }

        public void OnGet()
        {
            TestValue = "Gusts";
            Students = _studentRepository.GetAll().ToArray();
        }
    }
}
