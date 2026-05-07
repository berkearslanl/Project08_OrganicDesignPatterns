using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.SaleBannerRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.ViewComponents
{
    public class SaleBannerViewComponent : ViewComponent
    {
        private readonly ISaleBannerRepository _saleBannerRepository;

        public SaleBannerViewComponent(ISaleBannerRepository saleBannerRepository)
        {
            _saleBannerRepository = saleBannerRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _saleBannerRepository.GetAllAsync();
            return View(values);
        }
    }
}
