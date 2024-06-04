using Microsoft.AspNetCore.Mvc;
using OnlineSchool.Data.Models;
using OnlineSchool.Data.Repositories;
using OnlineSchool.Services;

namespace OnlineSchool.Controllers
{
    public class RegistrationController : Controller
    {
        AppDbContext db;
        public RegistrationController(AppDbContext db)
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
            return View("~/Views/Reg.cshtml");
        }


        [HttpPost]
        public IActionResult Index(SignUpDto signUp)
        {
            var rep = new ClientRepositoryImpl(db);
            Client user = rep.GetUserByEmail(signUp.Email);

            if (signUp.Email == null || signUp.Password == null || signUp.FirstName == null || signUp.SecondName == null)
            {
                ViewBag.Error = "Все поля должны быть заполнены";
                return View("~/Views/Reg.cshtml");
            }

            if (user == null)
            {
                Client new_user = new Client
                {
                    Name = signUp.FirstName,
                    Surname = signUp.SecondName,
                    Password = UserService.GetHashString(signUp.Password.ToString()),
                    Email = signUp.Email,
                    Role = Role.NOT_ADMIN
                };
                rep.SaveUser(new_user);
                HttpContext.Session.SetString("email", signUp.Email);

                return Redirect("~/Profile");
            }

            ViewBag.Error = "Пользователь с таким номером почтовым адресом уже существует, пожалуйста, войдите в свой аккаунт";
            return View("~/Views/Login.cshtml");
        }
    }
}
