using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Domain.Interfaces.Repositories;
using URLShortener.Domain.Models;
using URLShortener.JwtFeatures;

namespace URLShortener.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtHandler _jwtHandler;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, JwtHandler handler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtHandler = handler;
        }
        public IActionResult Login()
        {
            var response = new LoginModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);

            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, true, false);
                    if (result.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        var jwttoken = _jwtHandler.CreateJWT(user, roles[0]);

                        return RedirectToAction("Index", "Home", new {token = jwttoken});
                    }
                    TempData["Error"] = "Wrong credentials. Please try again";
                    return View(loginModel);
                }
            }
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginModel);

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetUser(string name)
        {
            var pass = new UserModelToGet();

            if (name != "")
            {
                var user = await _userManager.FindByNameAsync(name);
                var roles = await _userManager.GetRolesAsync(user);

                pass = new UserModelToGet();

                pass.Id = user.Id.ToString();
                if (roles != null)
                {
                    pass.Role = roles[0];
                }

                pass.IsAuth = true;
            } else
            {

                pass = new UserModelToGet();
            }
            

            return Ok(pass);
        }
    }
}
