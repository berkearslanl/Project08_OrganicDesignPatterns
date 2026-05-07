using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.FeaturedProductRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.ViewComponents
{
    public class FeaturedProductsViewComponent : ViewComponent
    {
        private readonly IFeaturedProductRepository _featuredProductRepository;

        public FeaturedProductsViewComponent(IFeaturedProductRepository featuredProductRepository)
        {
            _featuredProductRepository = featuredProductRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featuredProductRepository.GetAllAsync();
            return View(values);
        }
    }
}
