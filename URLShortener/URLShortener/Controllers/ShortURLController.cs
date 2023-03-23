using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace URLShortener.Controllers
{
    [Authorize]
    public class ShortURLController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
