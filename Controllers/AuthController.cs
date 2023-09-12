using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class AuthController : Controller
    {
        private IUser userService;
        public AuthController(IUser service)
        {
            userService = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();

        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> SignUp(RegisterUserDTO data)
        {

            data.Roles = new List<string>() { "Editor" };

            var user = await userService.Register(data, this.ModelState);
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> LogIn(LogInDTO loginData)
        {

            var user = await userService.Authenticate(loginData.UserName, loginData.Password);

            if (user == null)
            {
                this.ModelState.AddModelError("InvalidLogin", "Invalid login attempt");

                return RedirectToAction("LogIn");
            }

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Remmber (string name)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(5);
            HttpContext.Response.Cookies.Append("name", name, cookie);
            return Content("Ok , i save it ");
        }
        public IActionResult ThisIsMe()
        {
            string name = HttpContext.Request.Cookies["name"];
            ViewData["name"] = name;
            ViewBag.Name = name;
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}

    
