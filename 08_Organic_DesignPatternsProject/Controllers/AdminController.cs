using _08_Organic_DesignPatternsProject.Entities;
using _08_Organic_DesignPatternsProject.Repositories.CategoryRepository;
using _08_Organic_DesignPatternsProject.Repositories.CouponRepository;
using _08_Organic_DesignPatternsProject.Repositories.OrderRepository;
using _08_Organic_DesignPatternsProject.Repositories.ProductRepository;
using _08_Organic_DesignPatternsProject.Repositories.SubscriberRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.BannerRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.ServiceRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.FeaturedProductRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.TrendRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.QualityRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.SaleBannerRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.GalleryRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using _08_Organic_DesignPatternsProject.State;

namespace _08_Organic_DesignPatternsProject.Controllers
{
    public class AdminController : Controller
    {
        // Mevcut repository'ler
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISubscriberRepository _subscriberRepository;

        // Ana sayfa yönetimi repository'leri
        private readonly IBannerRepository _bannerRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IFeaturedProductRepository _featuredProductRepository;
        private readonly ITrendRepository _trendRepository;
        private readonly IQualityRepository _qualityRepository;
        private readonly ISaleBannerRepository _saleBannerRepository;
        private readonly IGalleryRepository _galleryRepository;

        public AdminController(
            ICategoryRepository categoryRepository,
            ICouponRepository couponRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            ISubscriberRepository subscriberRepository,
            IBannerRepository bannerRepository,
            IServiceRepository serviceRepository,
            IFeaturedProductRepository featuredProductRepository,
            ITrendRepository trendRepository,
            IQualityRepository qualityRepository,
            ISaleBannerRepository saleBannerRepository,
            IGalleryRepository galleryRepository)
        {
            _categoryRepository = categoryRepository;
            _couponRepository = couponRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _subscriberRepository = subscriberRepository;
            _bannerRepository = bannerRepository;
            _serviceRepository = serviceRepository;
            _featuredProductRepository = featuredProductRepository;
            _trendRepository = trendRepository;
            _qualityRepository = qualityRepository;
            _saleBannerRepository = saleBannerRepository;
            _galleryRepository = galleryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var order = await _orderRepository.GetAllAsync();
            ViewBag.TotalOrders = order.Count;

            var product = await _productRepository.GetAllAsync();
            ViewBag.TotalProducts = product.Count;

            var subscribe = await _subscriberRepository.GetAllAsync();
            ViewBag.TotalSubscribers = subscribe.Count;

            ViewBag.TotalRevenue = order.Sum(x => x.TotalAmount).ToString("C2", new System.Globalization.CultureInfo("tr-TR"));
            ViewBag.RecentOrders = order.OrderByDescending(x => x.OrderId).Take(7).ToList();

            return View();
        }
        public async Task<IActionResult> Orders()
        {
            var orders = await _orderRepository.GetAllAsync();
            ViewBag.Contexts = orders.ToDictionary
                (
                    o => o.OrderId,
                    o => new OrderContext(o.Status)
                );
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, string action)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                return NotFound();

            var context = new OrderContext(order.Status);

            switch (action)
            {
                case "ship": context.Ship(); break;
                case "deliver": context.Deliver(); break;
                case "cancel": context.Cancel(); break;
            }

            await _orderRepository.UpdateStatusAsync(orderId, context.CurrentStateName);
            return RedirectToAction("Orders");
        }
        public async Task<IActionResult> Products()
        {
            ViewBag.Categories = await _categoryRepository.GetAllAsync();
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _productRepository.CreateAsync(product);
            return RedirectToAction("Products");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction("Products");
        }
        public async Task<IActionResult> Categories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            await _categoryRepository.CreateAsync(category);
            return RedirectToAction("Categories");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return RedirectToAction("Categories");
        }
        public async Task<IActionResult> Coupons()
        {
            var coupons = await _couponRepository.GetAllAsync();
            return View(coupons);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(Coupon coupon)
        {
            await _couponRepository.CreateAsync(coupon);
            return RedirectToAction("Coupons");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _couponRepository.DeleteAsync(id);
            return RedirectToAction("Coupons");
        }
        public async Task<IActionResult> Subscribers()
        {
            var subscribers = await _subscriberRepository.GetAllAsync();
            return View(subscribers);
        }
        public async Task<IActionResult> Banners()
        {
            var banners = await _bannerRepository.GetAllAsync();
            return View(banners);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(Banner banner)
        {
            await _bannerRepository.CreateAsync(banner);
            return RedirectToAction("Banners");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _bannerRepository.DeleteAsync(id);
            return RedirectToAction("Banners");
        }

        public async Task<IActionResult> HomeServices()
        {
            var services = await _serviceRepository.GetAllAsync();
            return View(services);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHomeService(Service service)
        {
            await _serviceRepository.CreateAsync(service);
            return RedirectToAction("HomeServices");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHomeService(int id)
        {
            await _serviceRepository.DeleteAsync(id);
            return RedirectToAction("HomeServices");
        }

        public async Task<IActionResult> FeaturedSection()
        {
            var items = await _featuredProductRepository.GetAllAsync();
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeaturedSection(FeaturedProduct featuredProduct)
        {
            await _featuredProductRepository.CreateAsync(featuredProduct);
            return RedirectToAction("FeaturedSection");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFeaturedSection(int id)
        {
            await _featuredProductRepository.DeleteAsync(id);
            return RedirectToAction("FeaturedSection");
        }
        public async Task<IActionResult> Trends()
        {
            var trends = await _trendRepository.GetAllAsync();
            return View(trends);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrend(Trend trend)
        {
            await _trendRepository.CreateAsync(trend);
            return RedirectToAction("Trends");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTrend(int id)
        {
            await _trendRepository.DeleteAsync(id);
            return RedirectToAction("Trends");
        }
        public async Task<IActionResult> Quality()
        {
            var quality = await _qualityRepository.GetAllAsync();
            return View(quality);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuality(Quality quality)
        {
            if (quality.QualityId == 0)
            {
                // Veritabanında henüz kayıt yoksa oluştur
                await _qualityRepository.CreateAsync(quality);
            }
            else
            {
                await _qualityRepository.UpdateAsync(quality);
            }
            return RedirectToAction("Quality");
        }

        public async Task<IActionResult> SaleBanners()
        {
            var saleBanners = await _saleBannerRepository.GetAllAsync();
            return View(saleBanners);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSaleBanner(SaleBanner saleBanner)
        {
            await _saleBannerRepository.CreateAsync(saleBanner);
            return RedirectToAction("SaleBanners");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSaleBanner(int id)
        {
            await _saleBannerRepository.DeleteAsync(id);
            return RedirectToAction("SaleBanners");
        }
        public async Task<IActionResult> Gallery()
        {
            var gallery = await _galleryRepository.GetAllAsync();
            return View(gallery);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGallery(Gallery gallery)
        {
            await _galleryRepository.CreateAsync(gallery);
            return RedirectToAction("Gallery");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGallery(int id)
        {
            await _galleryRepository.DeleteAsync(id);
            return RedirectToAction("Gallery");
        }
    }
}
