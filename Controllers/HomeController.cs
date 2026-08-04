using IT_Company_web.Data;
using IT_Company_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IT_Company_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // ==========================
        // Contact Page (GET)
        // ==========================
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        // ==========================
        // Contact Page (POST)
        // ==========================
        [HttpPost]
        public async Task<IActionResult> Contact(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(model);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Your message has been sent successfully.";

                return RedirectToAction("Contact");
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}