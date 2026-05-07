using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.TrendRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.ViewComponents
{
    public class TrendSectionViewComponent : ViewComponent
    {
        private readonly ITrendRepository _trendRepository;

        public TrendSectionViewComponent(ITrendRepository trendRepository)
        {
            _trendRepository = trendRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _trendRepository.GetAllAsync();
            return View(values);
        }
    }
}
