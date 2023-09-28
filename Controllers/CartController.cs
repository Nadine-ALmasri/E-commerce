using E_commerce.Models;
using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using E_commerce.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Numerics;
using System.Security.Claims;

namespace E_commerce.Controllers
{
    public class CartController : Controller
    {
        private readonly CartServices _CartService;
        private UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        public CartController(CartServices CartService, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _CartService = CartService;
            _userManager = userManager;
            _emailSender=emailSender;   

        }
        [Authorize(Roles = "Administrator,Editor,User")]
        public async Task<IActionResult> Index(string layout)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {

                return RedirectToAction("Error");
            }

            var cart = await _CartService.GetCart(userId);
            ViewBag.Total = CalculateTotal();
            if (layout == "_Layout1")
                ViewBag.Layout = "_Layout1";
            else
                ViewBag.Layout = "_Layout";
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
            var ProductInCart = cart.CartProducts.FirstOrDefault(x => x.ProductId == id);
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
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);
            ViewBag.Email = user.Email;
            var shoppingCart = await _CartService.GetCart(userId);
            shoppingCart.Total = await CalculateTotal();

            var cartProductsDTO = new List<CartProductDTO>(); 

            foreach (var item in shoppingCart.CartProducts)
            {
                
                var cartProductDTO = new CartProductDTO
                {
                    ProductId = item.ProductId,
                    
                    Product = new ProductCategoryEmailDTO 
                    {
                       Id=item.Product.Id,
                       Name=item.Product.Name,
                       Price = item.Product.Price,

                    },
                    Quantity = item.Quantity
                };

                cartProductsDTO.Add(cartProductDTO); 
            }

            var userWithEmailAndCart = new UserEmailDTO
            {
                Email = user.Email,
                UserName = user.UserName,
                ShoppingCart = new CartEmail
                {
                    Total = shoppingCart.Total,
                    CartProducts = cartProductsDTO 
                },
                Phone = user.PhoneNumber,
               
            };

            return View("Checkout", userWithEmailAndCart);
        }


        [HttpPost]
        public async Task<IActionResult> ProcessOrder(UserEmailDTO user)
        {
            if (ModelState.IsValid)
            {
                string email = user.Email;
                string subject = "Thank you for your purchase. Here are the details of your order:\n\n";
                string HtmlMessage = "<table border='1'><tr><th>Product</th><th>Quantity</th><th>Price</th></tr>";

                foreach (var product in user.ShoppingCart.CartProducts)
                {
                    HtmlMessage += $"<tr><td>{product.Product.Name}</td><td>{product.Quantity}</td><td>{product.Product.Price}</td></tr>";
                }

                HtmlMessage += $"<tr><td colspan='2'><strong>Total:</strong></td><td>{user.ShoppingCart.Total}</td></tr></table>";

                await _emailSender.SendEmailAsync(email, subject, HtmlMessage);
            }

            return View("Thanks");
        }
    }
}
