using Microsoft.AspNetCore.Mvc;

namespace URLShortener.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
