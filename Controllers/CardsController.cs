using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Data.interfaces;
using OnlineSchool.Data.Models;
using OnlineSchool.Data.Repositories;

namespace OnlineSchool.Controllers
{
    public class CardsController : Controller
    {
        private readonly CourseRepository _courseRepo;

        AppDbContext db;
        public CardsController(AppDbContext db, CourseRepository courseRepo)
        {
            this.db = db;
            _courseRepo = courseRepo;
        }

        public ViewResult Card(int id)
        {
            return View(_courseRepo.getObjectCourse(id));
        }

        public IActionResult Index()
        {
            var course_rep = new CourseRepositoryImpl(db);
            var us_rep = new ClientRepositoryImpl(db);

            ViewBag.user = us_rep.GetUserByEmail(HttpContext.Session.GetString("email"));
            ViewBag.courses = course_rep.GetCourses();
            return View("~/Views/Courses/List.cshtml");
        }

        [HttpPost]
        public IActionResult Reserve(int courseid)
        {
            if (HttpContext.Session.GetString("email") == null) 
                return Redirect("~/Registration");
            var course_rep = new CourseRepositoryImpl(db);
            var us_rep = new ClientRepositoryImpl(db);
            var order_rep = new OrderRepositoryImpl(db);

            string email = HttpContext.Session.GetString("email");
            Client client = us_rep.GetUserByEmail(email);
            order_rep.AddToOrder(client, course_rep.getObjectCourse(courseid));

            //ViewBag.client = client;
            //ViewBag.courses = order_rep.GetAllCoursesByClientID(client.Id);

            return Redirect("~/Profile");
        }
    }
}
