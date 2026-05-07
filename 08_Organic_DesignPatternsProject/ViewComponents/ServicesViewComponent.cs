using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.ServiceRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.ViewComponents
{
    public class ServicesViewComponent : ViewComponent
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesViewComponent(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _serviceRepository.GetAllAsync();
            return View(values);
        }
    }
}
