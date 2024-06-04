using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Data.Models;
using OnlineSchool.Data.Repositories;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.ConstrainedExecution;

namespace OnlineSchool.Controllers
{
    public class ProfileController : Controller
    {
        AppDbContext db;
        public ProfileController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            string email = HttpContext.Session.GetString("email");
            if (email == null)
            {
                return Redirect("~/Login");
            }
            var order_rep = new OrderRepositoryImpl(db);
            var us_rep = new ClientRepositoryImpl(db);
            Client client = us_rep.GetUserByEmail(HttpContext.Session.GetString("email"));
            ViewBag.client = client;
            if (order_rep.AnyOrder(client) == true)
            {
                ViewBag.courses = order_rep.GetAllCoursesByClientID(client.Id);
                ViewBag.empty = 0;
            }
            else ViewBag.empty = 1;

            return View("~/Views/Profile.cshtml");
        }
        public IActionResult Edit(string Name, string Surname)
        {
            if (Name == null || Surname == null)
            {
                ViewBag.Error = "Все поля должны быть заполнены";
                return Redirect("~/Profile");
            }
            var rep = new ClientRepositoryImpl(db);
            Client user = rep.GetUserByEmail(HttpContext.Session.GetString("email"));
            user.Name = Name;
            user.Surname = Surname;

            rep.SaveUser(user);
            return Redirect("~/Profile");
        }

        public IActionResult Delete()
        {
            var rep = new ClientRepositoryImpl(db);
            Client user = rep.GetUserByEmail(HttpContext.Session.GetString("email"));
            rep.DeleteUser(user);
            HttpContext.Session.Clear();
            return Redirect("~/");
        }

        public IActionResult ReadDoc(int id)
        {
            var rep = new CourseRepositoryImpl(db);
            Course course = rep.getObjectCourse(id);
            string fileName = course.path;
            /*string outputDirectory = ("Out/");
            string outputFilePath = Path.Combine(outputDirectory, "output.pdf");
            using (Viewer viewer = new Viewer("SourceDocuments/" + fileName))
            {
                PdfViewOptions options = new PdfViewOptions(outputFilePath);
                viewer.View(options);
            }*/
            var fileStream = new FileStream("SourceDocuments/" + fileName,
                    FileMode.Open,
                    FileAccess.Read
                    );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
        }

        public IActionResult DeleteCourse(int id)
        {
            var orep = new OrderRepositoryImpl(db);
            var rep = new ClientRepositoryImpl(db);
            Client user = rep.GetUserByEmail(HttpContext.Session.GetString("email"));
            orep.DeleteCourse(id, user);
            return Redirect("~/Profile");

        }

        public IActionResult Enter()
        {
            var rep = new ClientRepositoryImpl(db);
            Client user = rep.GetUserByEmail(HttpContext.Session.GetString("email"));
            HttpContext.Session.Clear();
            return Redirect("~/Registration");
        }
    }
}
