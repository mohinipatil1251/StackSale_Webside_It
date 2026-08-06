using IT_Company_web.Interface;
using IT_Company_web.Interface;
using IT_Company_web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace IT_Company_web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IWebHostEnvironment _environment;

        public ServiceController(IServiceRepository serviceRepository,
                                 IWebHostEnvironment environment)
        {
            _serviceRepository = serviceRepository;
            _environment = environment;
        }

        // =========================
        // WEBSITE SERVICES PAGE
        // =========================

        public IActionResult Index()
        {
            var services = _serviceRepository.GetAll();
            return View(services);
        }

        // =========================
        // ADMIN SERVICE LIST
        // =========================

        public IActionResult AdminIndex()
        {
            var services = _serviceRepository.GetAll();
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

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string fileName = Guid.NewGuid().ToString() +
                                      Path.GetExtension(service.ImageFile.FileName);

                    string filePath = Path.Combine(folder, fileName);

                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        service.ImageFile.CopyTo(stream);
                    }

                    service.Image = fileName;
                }

                _serviceRepository.Add(service);
                _serviceRepository.Save();

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
            var service = _serviceRepository.GetById(id);

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
                if (service.ImageFile != null)
                {
                    string folder = Path.Combine(_environment.WebRootPath, "Image");

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string fileName = Guid.NewGuid().ToString() +
                                      Path.GetExtension(service.ImageFile.FileName);

                    string filePath = Path.Combine(folder, fileName);

                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        service.ImageFile.CopyTo(stream);
                    }

                    service.Image = fileName;
                }

                _serviceRepository.Update(service);
                _serviceRepository.Save();

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
            var service = _serviceRepository.GetById(id);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _serviceRepository.Delete(id);
            _serviceRepository.Save();

            return RedirectToAction("AdminIndex");
        }
    }
}