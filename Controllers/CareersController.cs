using IT_Company_web.Data;
using IT_Company_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT_Company_web.Controllers
{
    public class CareersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================
        // Career List
        // =====================================
        public IActionResult Index()
        {
            //  var careers = _context.Careers.ToList();
            // return View(careers);
            return View();
        }

        // =====================================
        // Apply Form
        // =====================================
        [HttpGet]
        public IActionResult Apply(int id)
        {
            var career = _context.Careers.FirstOrDefault(x => x.Id == id);

            if (career == null)
            {
                return NotFound();
            }

            ViewBag.Career = career;

            JobApplication application = new JobApplication
            {
                CareerId = id
            };

            return View(application);
        }

        // =====================================
        // Save Application
        // =====================================
        [HttpPost]
        public IActionResult Apply(JobApplication application)
        {
            // Navigation Property Validation Remove
            ModelState.Remove("Career");

            // Resume Upload नंतर करणार असल्यामुळे
            ModelState.Remove("ResumePath");

            if (ModelState.IsValid)
            {
                application.AppliedDate = DateTime.Now;

                // सध्या Resume Upload नाही
                application.ResumePath = "";

                _context.JobApplications.Add(application);
                _context.SaveChanges();

                TempData["Success"] = "Application Submitted Successfully.";

                return RedirectToAction("Index");
            }

            // Validation fail झाली तर Job Details पुन्हा पाठव
            ViewBag.Career = _context.Careers.FirstOrDefault(x => x.Id == application.CareerId);

            return View(application);
        }
    }
}