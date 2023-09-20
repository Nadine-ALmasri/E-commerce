using E_commerce.Models;
using E_commerce.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_commerce.Controllers
{
    public class CartController : Controller
    {
         private readonly CartServices _CartService;
        
         public CartController(CartServices CartService)
         {
             _CartService = CartService;
           
         }
        [Authorize(Roles = "Administrator,Editor,User")]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                
                return RedirectToAction("Error"); 
            }

            var cart = await _CartService.GetCart(userId);
            return View(cart);
        }

    }
}

