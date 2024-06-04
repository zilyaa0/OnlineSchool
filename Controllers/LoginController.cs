using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Data.Models;
using OnlineSchool.Data.Repositories;
using OnlineSchool.Services;

namespace OnlineSchool.Controllers 
{
    public class LoginController : Controller
    {
        AppDbContext db;
        public LoginController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            string email = HttpContext.Session.GetString("email");
            if (email != null)
            {
                return Redirect("~/Profile");
            }
            return View("~/Views/Login.cshtml");
        }
        [HttpPost]
        public IActionResult Index(SignInDto signIn)
        {
            var rep = new ClientRepositoryImpl(db);
            Client user = rep.GetUserByEmail(signIn.Email);

            if (signIn.Email == null || signIn.Password == null)
            {
                ViewBag.Error = "Все поля должны быть заполнены";
                return View("~/Views/Reg.cshtml");
            }

            if (user != null)
            {
                if (user.Password == UserService.GetHashString(signIn.Password))
                {
                    HttpContext.Session.SetString("email", signIn.Email);
                    return Redirect("~/Profile");
                }

            }
            ViewBag.Error = "Пользователь с такими данными не найден";
            return View("~/Views/Login.cshtml");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("~/Login");
        }
    }
}
