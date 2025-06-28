using System.Linq;
using System.Web.Mvc;
using TICKET.Models;
using System.Security.Cryptography;
using System.Text;

namespace TICKET.Controllers
{
    public class AccountController : Controller
    {
        private BookingDbContext db = new BookingDbContext();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Phone = model.Phone,
                    PasswordHash = HashPassword(model.Password),
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth
                };

                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        public ActionResult Login()
        {
            ViewBag.Roles = new SelectList(new[] { "SuperAdmin", "Manager" });
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user != null && user.PasswordHash == HashPassword(model.Password))
                {
                    Session["UserID"] = user.UserID;
                    Session["Role"] = "User";
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Email hoặc mật khẩu không đúng");
            }

            return View(model);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return System.Convert.ToBase64String(hash);
            }
        }
    }
}
