using E_commerce.Models;
using E_commerce.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class CartController : Controller
    {
        /* private readonly CartServies _CartService;
         private readonly ProductServices _productService; // You may have a ProductService to manage products.

         public CartController(CartServies CartService, ProductServices productService)
         {
             _CartService = CartService;
             _productService = productService;
         }*/
        [Authorize(Roles = "Administrator,Editor,User")]
        public IActionResult Index()
        {

            return View();
        }
    }
    }

