using Microsoft.AspNetCore.Mvc;

namespace IT_Company_web.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
