using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.QualityRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.ViewComponents
{
    public class QualitySectionViewComponent : ViewComponent
    {
        private readonly IQualityRepository _qualityRepository;

        public QualitySectionViewComponent(IQualityRepository qualityRepository)
        {
            _qualityRepository = qualityRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _qualityRepository.GetAllAsync();
            return View(values);
        }
    }
}
