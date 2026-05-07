using Microsoft.AspNetCore.Mvc;

namespace _08_Organic_DesignPatternsProject.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
