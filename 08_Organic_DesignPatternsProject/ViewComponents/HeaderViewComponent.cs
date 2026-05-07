using Microsoft.AspNetCore.Mvc;

namespace _08_Organic_DesignPatternsProject.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
