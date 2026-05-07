using _08_Organic_DesignPatternsProject.Repositories.ProductRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ShopController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> ShopList(int? categoryId, decimal? minPrice, decimal? maxPrice, bool? isOrganic)
        {
            //dropdown'a kategori çekmek için
            var categories = await _productRepository.GetCategoriesAsync();
            ViewBag.Categories = categories;

            //filtre değerleri seçilmediyse
            if (categoryId == null && minPrice == null && maxPrice == null && isOrganic == null)
            {
                var values = await _productRepository.GetAllAsync();
                return View(values);
            }

            var filteredValue = await _productRepository.GetFilteredAsync(categoryId, minPrice, maxPrice, isOrganic);
            return View(filteredValue);
        }
        public async Task<IActionResult> ProductDetail(int id)
        {
            var value = await _productRepository.GetByIdAsync(id);
            if (value == null)
                return NotFound();
            return View(value);
        }
    }
}
