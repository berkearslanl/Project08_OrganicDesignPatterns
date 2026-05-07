using Microsoft.AspNetCore.Mvc;

namespace _08_Organic_DesignPatternsProject.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
