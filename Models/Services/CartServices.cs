﻿using E_commerce.Data;
using E_commerce.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_commerce.Models.Services
{
    public class CartServices : ICart
    {
        private readonly E_commerceDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartServices(E_commerceDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddToCart(Product product, int Amount)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            // Get or create the user's cart.
            var userCart = await GetCart(userId);

            var cartProduct = userCart?.CartProducts?.FirstOrDefault(cp => cp.Product.Id == product.Id);

            if (cartProduct != null)
            {
                cartProduct.Quantity += Amount;
            }
            else
            {
                // If the product is not in the cart, add it.
                cartProduct = new CartProduct
                {
                    Cart = userCart,
                    Product = product,
                    Quantity = Amount
                };
                _context.CartProducts.Add(cartProduct);
            }

            // Update the cart total.
            userCart.Total = userCart.CartProducts?.Sum(cp => cp.Product.Price * cp.Quantity) ?? 0;

            // Save the changes to the database.
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCart(string userId)
        {
            var userCart = await _context.Cart
                .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (userCart != null)
            {
                return userCart;
            }

            // If the user doesn't have a cart in the database, create a new cart for them.
            var newCart = new Cart
            {
                UserId = userId,
                // Other initialization logic for the cart properties.
                Total = 0,  // You can initialize other properties here.
                CartProducts = new List<CartProduct>()
            };

            // Add the new cart to the database.
            _context.Cart.Add(newCart);
            await _context.SaveChangesAsync();

            return newCart;
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        Task<Cart> ICart.GetCart(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
