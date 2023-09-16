using E_commerce.Models;
using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace E_commerce.Controllers
{
    public class AuthController : Controller
    {
        private IUser userService;
        private RoleManager<ApplicationUser> roles;
        public AuthController(IUser service, RoleManager<ApplicationUser> roles)
        {
            userService = service;
            this.roles = roles;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            //var Roles = roles.Roles.ToList();
            //ViewBag.RolesList = new SelectList(Roles, "Id", "Name");
            return View();

        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> SignUp(RegisterUserDTO data)
        {
            
                data.Roles = new List<string>() { "Administrator" };
            

            data.Roles = new List<string>() { "User" };

            var user = await userService.Register(data, this.ModelState);
            if (!ModelState.IsValid)
            {
                return View(user);
            }


            return RedirectToAction("LogIn");
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> LogIn(LogInDTO loginData)
        {

            var user = await userService.Authenticate(loginData.UserName, loginData.Password);

            if (user == null)
            {
                this.ModelState.AddModelError("InvalidLogin", "Invalid login attempt");

                return View(loginData);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , user.UserName)
            };
            var claimsIdentity = new ClaimsIdentity(claims , "LogIn");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


            return RedirectToAction("Index", "Home");
        }
      
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();

            return RedirectToAction("Index", "Home");
        }
        [HttpGet("Account/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}

    
