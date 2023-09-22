using E_commerce.Models;
using E_commerce.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            ViewBag.Total=CalculateTotal();
            return View(cart);
        }

        [ActionName("DeleteProductFromCart")]
        public async Task<IActionResult> DeleteProductFromCartGet(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {

                return RedirectToAction("Error");
            }

            var cart = await _CartService.GetCart(userId);
            var ProductInCart = cart.CartProducts.FirstOrDefault(x=>x.ProductId==id);
            return View(ProductInCart);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductFromCart(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {

                return RedirectToAction("Error");
            }
            
            await _CartService.DeleteProduct(id);
            return RedirectToAction("Index");
        }


        public async Task<double> CalculateTotal()
        {
            Cart UserCart = null;
            double total = 0;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                UserCart = await _CartService.GetCart(userId);
                if (UserCart.CartProducts != null)
                {
                    foreach (var item in UserCart.CartProducts)
                    {
                        if (item.Product != null)
                        {
                            total += item.Product.Price;
                        }
                    }
                }
                else
                {
                    return total;
                }
            }
                return total;
        }




    }
}

