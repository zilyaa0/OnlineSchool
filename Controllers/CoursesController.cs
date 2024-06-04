using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Data.interfaces;

namespace OnlineSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CourseRepository _courses;

        public CoursesController (CourseRepository courses)
        {
            _courses = courses;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с курсами";
            var courses = _courses.GetCourses();
            
            return View(courses);
        }
    }
}
