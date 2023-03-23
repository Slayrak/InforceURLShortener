using Microsoft.AspNetCore.Mvc;

namespace URLShortener.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
