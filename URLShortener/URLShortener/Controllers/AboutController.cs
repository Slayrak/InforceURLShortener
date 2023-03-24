using Microsoft.AspNetCore.Mvc;
using URLShortener.Domain.Interfaces.Services;

namespace URLShortener.Controllers
{
    public class AboutController : Controller
    {
        private readonly IURLService _urlService;

        public AboutController(IURLService urlService)
        {
            _urlService = urlService;
        }

        public async Task<IActionResult> Index(bool check)
        {
            var about = await _urlService.GetAbout();
            TempData["Show"] = check;
            return View(about);
        }

        public async Task ChangeView(string textToChange)
        {
            var about = await _urlService.GetAbout();
            about.Content = textToChange;
            _urlService.UpdateAbout(about);
        }
    }
}
