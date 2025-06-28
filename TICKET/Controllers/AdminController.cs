using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using TICKET.Models;

namespace TICKET.Controllers
{
    public class AdminController : Controller
    {
        private readonly BookingDbContext db = new BookingDbContext();

        public ActionResult Login()
        {
            ViewBag.Roles = new SelectList(new[] { "SuperAdmin", "Manager" });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password, string role)
        {
            var passwordHash = Crypto.HashPassword(password);
            var admin = db.Admins.FirstOrDefault(a => a.Email == email && a.Role == role);

            if (admin != null && Crypto.VerifyHashedPassword(admin.PasswordHash, password))
            {
                Session["AdminEmail"] = admin.Email;
                Session["AdminRole"] = admin.Role;
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Sai thông tin đăng nhập hoặc vai trò.";
            ViewBag.Roles = new SelectList(new[] { "SuperAdmin", "Manager" });
            return View();
        }

        public ActionResult Dashboard()
        {
            if (Session["AdminEmail"] == null) return RedirectToAction("Login");
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

