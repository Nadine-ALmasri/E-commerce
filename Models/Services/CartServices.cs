﻿using E_commerce.Data;
using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace E_commerce.Models.Services
{
    public class CartServices : ICart
    {
        private readonly E_commerceDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CartServices(E_commerceDbContext context, IHttpContextAccessor httpContextAccessor, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _signInManager=signInManager;
        }
        [HttpPost]
        public async Task<List<CartProducts>> AddToCart(ProductCategoryDTO product)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }

            // Get or create the user's Cart.
            var userCart =await _context.Cart.FirstOrDefaultAsync(c => c.UserId == userId);
            if(userCart == null)
            {
                return null;
            }
            var CartofUser = await _context.Cart.Where(x => x.UserId == userId).SelectMany(x => x.CartProducts).FirstOrDefaultAsync(x => x.ProductId == product.Id);
            //var CartProduct = userCart?.CartProducts?.FirstOrDefault(cp => cp.Product.Id == product.Id);

            if (CartofUser != null)
            {
                CartofUser.Quantity += 1;
            }
            else
            {
                // If the product is not in the Cart, add it.
                Product pro = new Product
                { Description = product.Description,
                    imageUrl = product.ImageUrl,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Id = product.Id,


                };
                CartofUser = new CartProducts
                {
                    Cart = userCart, // This should work with the updated ForeignKey attribute.
                    ProductId = pro.Id,
                    Quantity = 1,
                    UserId = userId,
                };
                _context.CartProducts.Add(CartofUser);
                await _context.SaveChangesAsync();
            }

            // Update the Cart total.
           

            // Save the changes to the database.
            await _context.SaveChangesAsync();
            //var CartofUser = _context.Cart.Where(x => x.UserId == userId).SelectMany(x => x.CartProducts).ToList();
            /*var cartprice = CartofUser[0].Cart.CartProducts;
            foreach (var item in cartprice)
            {
                userCart.Total += item.Product.Price;
            }*/
            return userCart.CartProducts;
        }

         public async Task<Cart> GetCart(string userId)
          {
              var userCart = await _context.Cart
                  .Include(c => c.CartProducts)
                  .ThenInclude(cp => cp.Product)
                  .FirstOrDefaultAsync(c => c.UserId == userId);

             
                  return userCart;
              


              
          }


        //public async Task<List<CartProducts>> GetAlProductsInCart()
        //{
        //    var user = _signInManager.IsSignedIn()
        //    var CartProducts = await _context.Cart.Include(cp=>cp.CartProducts).ThenInclude(p=>p.Product).ThenInclude(c=>c.Category).Where();
        //}
        public async Task DeleteProduct(int id)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            // Get or create the user's Cart.
            var userCart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == userId);
            var CartofUser =await _context.Cart.Where(x => x.UserId == userId).SelectMany(x => x.CartProducts).FirstOrDefaultAsync(x=>x.ProductId==id);
            if (CartofUser != null)
            {
               _context.CartProducts.Remove(CartofUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task LessQuantity(int id)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            // Get or create the user's Cart.
            var userCart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == userId);
            var CartofUser = await _context.Cart.Where(x => x.UserId == userId).SelectMany(x => x.CartProducts).FirstOrDefaultAsync(x => x.ProductId == id);
            if (CartofUser != null && CartofUser.Quantity>1)
            {
                CartofUser.Quantity--;
                await _context.SaveChangesAsync();
            }
            else if(CartofUser != null && CartofUser.Quantity == 1)
            {
                _context.CartProducts.Remove(CartofUser);
                await _context.SaveChangesAsync();
            }
        }
    }
}
