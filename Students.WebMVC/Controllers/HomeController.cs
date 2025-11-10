using Microsoft.AspNetCore.Mvc;
using Students.WebMVC.Models;
using System.Diagnostics;
using Students.DataAccess.Interfaces;

namespace Students.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository _studentRepository;

        public HomeController(ILogger<HomeController> logger,
            IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            var model = new IndexModel()
            {
                Greeting = "Hi Gusts!",
                Students = _studentRepository.GetAll().ToArray()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
