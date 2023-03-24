using Microsoft.AspNetCore.Mvc;
using URLShortener.Domain.Interfaces.Services;

namespace URLShortener.Controllers
{
    public class TableAndInfoController : Controller
    {
        private readonly IURLService _urlService;

        public TableAndInfoController(IURLService urlService)
        {
            _urlService = urlService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
