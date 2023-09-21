using E_commerce.Models;
using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;

namespace E_commerce.Controllers
{
    public class AuthController : Controller
    {
        private IUser userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthController(IUser service, RoleManager<IdentityRole> roleManager)
        {
            userService = service;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SignUp()
        {
            //var Roles = await _roleManager.Roles.ToListAsync();
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

            if (data.Roles==null)
            {
                data.Roles = new List<string>() { "Administrator" };
            }
            
            var user = await userService.Register(data, this.ModelState);
            if (!ModelState.IsValid)
            {
                //var Roles = await _roleManager.Roles.ToListAsync();
                //ViewBag.RolesList = new SelectList(Roles, "Id", "Name");
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

            var shoppingCart = userService.LoadShoppingCartForUser(user);

            // Add the shopping Cart to the user's claims
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim("ShoppingCart", JsonConvert.SerializeObject(shoppingCart)) // Serialize the shopping Cart
    };

            var claimsIdentity = new ClaimsIdentity(claims, "LogIn");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            if(user.Roles.Contains("User"))
            {
                return RedirectToAction("Index","Product");
            }

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

    
