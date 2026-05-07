using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.GalleryRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.ViewComponents
{
    public class InstagramSectionViewComponent : ViewComponent
    {
        private readonly IGalleryRepository _galleryRepository;

        public InstagramSectionViewComponent(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _galleryRepository.GetAllAsync();
            return View(values);
        }
    }
}
