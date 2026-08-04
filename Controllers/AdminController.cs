using IT_Company_web.Data;
using IT_Company_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Company_web.Controllers
{
   




    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Login Page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login Check
        [HttpPost]
        public IActionResult Login(AdminUser model)
        {
            var admin = _context.AdminUsers.FirstOrDefault(x =>
                x.Username == model.Username &&
                x.Password == model.Password);

            if (admin != null)
            {
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid Username or Password";

            return View();
        }

        // Dashboard
        public IActionResult Dashboard()
        {
            return View();
        }

        // Contact Messages List
        public IActionResult ContactMessages()
        {
            var messages = _context.ContactMessages
                                   .OrderByDescending(x => x.CreatedDate)
                                   .ToList();

            return View(messages);
        }
    }
}
