using ProyectoFinal.Data;
using ProyectoFinal.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;


namespace ProyectoFinal.Controllers
{
    public class AccountController : Controller
    {
        private GameDbContext db = new GameDbContext();

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Verificar si el usuario ya existe
                var existingUser = db.Users.FirstOrDefault(u => u.Username == user.Username || u.Email == user.Email);

                if (existingUser != null)
                {
                    ModelState.AddModelError("", "El usuario o email ya existe");
                    return View(user);
                }

                // Hash de la contraseña (usar BCrypt en producción)
                user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "SHA1");
                user.DateCreated = DateTime.Now;

                db.Users.Add(user);
                db.SaveChanges();

                // Login automático después del registro
                FormsAuthentication.SetAuthCookie(user.UserId.ToString(), false);
                Session["UserId"] = user.UserId;
                Session["Username"] = user.Username;

                return RedirectToAction("Index", "Games");
            }

            return View(user);
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Usuario y contraseña son requeridos";
                return View();
            }

            string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserId.ToString(), false);
                Session["UserId"] = user.UserId;
                Session["Username"] = user.Username;

                return RedirectToAction("Index", "Games");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}