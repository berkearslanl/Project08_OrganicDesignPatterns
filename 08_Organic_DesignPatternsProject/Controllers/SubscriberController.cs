using _08_Organic_DesignPatternsProject.Observer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _08_Organic_DesignPatternsProject.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly NewsletterService _newsletterService;

        public SubscriberController(NewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            await _newsletterService.SubscribeAsync(email);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
