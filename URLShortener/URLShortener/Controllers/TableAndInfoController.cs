using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> URLInfo(long id)
        {
            return View(await _urlService.GetURLInfo(id));
        }

        public async Task<IActionResult> GetAllURLS()
        {
            var urls = await _urlService.GetAll();

            return Ok(urls); 
        }

        public IActionResult ToAngular()
        {
            return Redirect("http://localhost:4200/");
        }
    }
}
