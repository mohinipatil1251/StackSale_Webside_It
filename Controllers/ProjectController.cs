using IT_Company_web.Interface;
using IT_Company_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT_Company_web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IWebHostEnvironment _environment;

        public ProjectController(IProjectRepository projectRepository,
                                 IWebHostEnvironment environment)
        {
            _projectRepository = projectRepository;
            _environment = environment;
        }
        public IActionResult Index()

        {
            var projects = _projectRepository.GetAll();
            return View(projects);
           
        }
        // =========================
        // ADMIN PROJECT LIST
        // =========================

        public IActionResult AdminIndex()
        {
            var projects = _projectRepository.GetAll();
            return View(projects);
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
        public IActionResult Create(Project project, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string folder = Path.Combine(_environment.WebRootPath, "Image");

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string fileName = Guid.NewGuid().ToString() +
                                      Path.GetExtension(ImageFile.FileName);

                    string filePath = Path.Combine(folder, fileName);

                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    project.Image = fileName;
                }

                _projectRepository.Add(project);
                _projectRepository.Save();

                return RedirectToAction("AdminIndex");
            }

            return View(project);
        }
    }
}
    

