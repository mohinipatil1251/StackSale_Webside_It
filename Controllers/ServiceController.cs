using IT_Company_web.Data;
using IT_Company_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace IT_Company_web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ServiceController(ApplicationDbContext context,
                         IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        // Website Services Page
        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        // Admin Service List
        public IActionResult AdminIndex()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        // =========================
        // CREATE
        // =========================

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

         [HttpPost]
           public IActionResult Create(Service service)
           {
              if (ModelState.IsValid)
             {
             if (service.ImageFile != null)
             {
             string folder = Path.Combine(_environment.WebRootPath, "Image");

           string fileName = Guid.NewGuid().ToString() +
                        Path.GetExtension(service.ImageFile.FileName);

          string filePath = Path.Combine(folder, fileName);

           using (FileStream stream = new FileStream(filePath, FileMode.Create))
             {
              service.ImageFile.CopyTo(stream);
            }

           service.Image = fileName;
           }

           _context.Services.Add(service);

          _context.SaveChanges();

           return RedirectToAction("AdminIndex");
          }

          return View(service);
           }



        
        

           





        // =========================
        // EDIT
        // =========================

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var service = _context.Services.Find(id);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Update(service);
                _context.SaveChanges();

                return RedirectToAction("AdminIndex");
            }

            return View(service);
        }

        // =========================
        // DELETE
        // =========================

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var service = _context.Services.Find(id);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var service = _context.Services.Find(id);

            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }

            return RedirectToAction("AdminIndex");
        }
    }
}