using E_commerce.Models;
using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using E_commerce.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Stripe.Checkout;
using Stripe;
using System.Numerics;
using System.Security.Claims;
using Microsoft.CodeAnalysis;

namespace E_commerce.Controllers
{
    public class CartController : Controller
    {
        private readonly CartServices _CartService;
        private UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        public CartController(CartServices CartService, UserManager<ApplicationUser> userManager, IEmailSender emailSender , IConfiguration configuration)
        {
            _CartService = CartService;
            _userManager = userManager;
            _emailSender=emailSender;   
            _configuration = configuration;
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

        [Authorize(Roles = "Administrator,Editor,User")]
        [HttpPost]
        public async Task<IActionResult> LessQuantityCon(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {

                return RedirectToAction("Error");
            }

            await _CartService.LessQuantity(id);
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

            var UserOrder = new Order
            {UserId=user.Id ,
                Email = user.Email,
                UserName = user.UserName,
                ShoppingCart = new CartEmail
                {
                    Total = shoppingCart.Total,
                    CartProducts = cartProductsDTO 
                },
                Phone = user.PhoneNumber,
               
            };

            return View("Checkout", UserOrder);
        }
        [HttpPost]
        [ActionName("Checkout")]
        public async Task<IActionResult> CheckoutPOST(Order order)
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
						Id = item.Product.Id,
						Name = item.Product.Name,
						Price = item.Product.Price,

					},
					Quantity = item.Quantity
				};

				cartProductsDTO.Add(cartProductDTO);
			}
           
			var UserOrder = new Order
			{
				UserId = user.Id,
				Email = user.Email,
				UserName = user.UserName,
				ShoppingCart = new CartEmail
				{
					Total = shoppingCart.Total,
					CartProducts = cartProductsDTO
				},
				Phone = user.PhoneNumber,
                OrderDate= DateTime.Now,
                City= order.City,
                PostalCode= order.PostalCode,
                StreetAdress= order.StreetAdress,
			};
			StripeConfiguration.ApiKey = _configuration.GetSection("StripeSettings:SecretKey").Get<string>();

			var domain = "https://localhost:44388/";

			var options = new SessionCreateOptions
			{
				SuccessUrl = domain + "Cart/Thanks",
				CancelUrl = domain + "Cart/Index",
				LineItems = new List<SessionLineItemOptions>(),
				Mode = "payment",
			};

			foreach (var item in UserOrder.ShoppingCart.CartProducts)
			{
				var sessionLineItem = new SessionLineItemOptions
				{
					PriceData = new SessionLineItemPriceDataOptions()
					{
						UnitAmount = (long)(item.Product.Price * 100), // 20.50 => 2050
						Currency = "usd",
						ProductData = new SessionLineItemPriceDataProductDataOptions()
						{
							Name = item.Product.Name
						}
					},
					Quantity = item.Quantity
				};

				options.LineItems.Add(sessionLineItem);
			}

			var service = new SessionService();
			var session = service.Create(options);

			var sessionId = session.Id;

			TempData["sessionId"] = sessionId;


			Response.Headers.Add("Location", session.Url);

			return new StatusCodeResult(303);

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
