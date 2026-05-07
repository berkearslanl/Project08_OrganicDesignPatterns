using _08_Organic_DesignPatternsProject.ChainOfResponsibility;
using _08_Organic_DesignPatternsProject.Context;
using _08_Organic_DesignPatternsProject.Observer;
using _08_Organic_DesignPatternsProject.Observer.Observers;
using _08_Organic_DesignPatternsProject.Repositories.CartRepository;
using _08_Organic_DesignPatternsProject.Repositories.CategoryRepository;
using _08_Organic_DesignPatternsProject.Repositories.CouponRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.BannerRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.FeaturedProductRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.GalleryRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.QualityRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.SaleBannerRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.ServiceRepository;
using _08_Organic_DesignPatternsProject.Repositories.HomePageRepositories.TrendRepository;
using _08_Organic_DesignPatternsProject.Repositories.OrderRepository;
using _08_Organic_DesignPatternsProject.Repositories.ProductRepository;
using _08_Organic_DesignPatternsProject.Repositories.SubscriberRepository;
using _08_Organic_DesignPatternsProject.Services;
using _08_Organic_DesignPatternsProject.Strategies;
using _08_Organic_DesignPatternsProject.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<OrganicContext>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ISubscriberRepository, SubscriberRepository>();

builder.Services.AddScoped<IBannerRepository, BannerRepository>();
builder.Services.AddScoped<IFeaturedProductRepository, FeaturedProductRepository>();
builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
builder.Services.AddScoped<IQualityRepository, QualityRepository>();
builder.Services.AddScoped<ISaleBannerRepository, SaleBannerRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ITrendRepository, TrendRepository>();


builder.Services.AddScoped<OrderValidationChain>();

builder.Services.AddScoped<PaymentContext>();

builder.Services.AddSession();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<NewsletterService>();
builder.Services.AddScoped<OrderNotificationService>();

builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddScoped<EmailService>();


var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
