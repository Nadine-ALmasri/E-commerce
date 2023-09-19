using E_commerce.Data;
using E_commerce.Models.DTOs;
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

        public async Task AddToCart(ProductCategoryDTO product)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            // Get or create the user's Cart.
            var userCart = _context.Cart.FirstOrDefault(c => c.UserId == userId);

            var CartProduct = userCart?.CartProducts?.FirstOrDefault(cp => cp.Product.Id == product.Id);

            if (CartProduct != null)
            {
                CartProduct.Quantity += 1;
            }
            else
            {
                // If the product is not in the Cart, add it.
                Product pro = new Product
                {Description = product.Description ,
                imageUrl = product.ImageUrl ,
                Name = product.Name ,
                Price = product.Price ,
                CategoryId= product.CategoryId ,
                Id = product.Id ,


                };
                CartProduct = new CartProducts
                {
                    Cart = userCart, // This should work with the updated ForeignKey attribute.
                    ProductId = pro.Id,
                    Quantity = 1 
                };
                _context.CartProducts.Add(CartProduct);
                await _context.SaveChangesAsync();
            }

            // Update the Cart total.
            userCart.Total = userCart.CartProducts?.Sum(cp => cp.Product.Price * cp.Quantity) ?? 0;

            // Save the changes to the database.
            await _context.SaveChangesAsync();
        }

      /*  public async Task<Cart> GetCart(string userId)
        {
            var userCart = await _context.Cart
                .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (userCart != null)
            {
                return userCart;
            }

            
            // If the user doesn't have a Cart in the database, create a new Cart for them.
            else {
            var newCart = new Cart
            {
                UserId = userId,
                // Other initialization logic for the Cart properties.
                Total = 0,  // You can initialize other properties here.
                CartProducts = new List<CartProduct>()
            };

            // Add the new Cart to the database.
            _context.Cart.Add(newCart);
            await _context.SaveChangesAsync();

            return newCart; }
        }*/

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
