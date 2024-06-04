using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Data.interfaces;
using OnlineSchool.Data.Models;

namespace OnlineSchool.Controllers
{
    public class HomeController : Controller
    {
        private readonly CourseRepository _courseRepo;

        public HomeController(CourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public ViewResult Index()
        {
            return View();
        }
    }
}
