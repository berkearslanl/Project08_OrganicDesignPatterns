using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.BannerRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerViewComponent(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _bannerRepository.GetAllAsync();
            return View(value);
        }
    }
}
