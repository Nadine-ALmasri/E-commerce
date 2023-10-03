using E_commerce.Data;
using E_commerce.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Models.Services
{
    public class OrderServices : IOrder
    {
        private readonly E_commerceDbContext _context;

        public OrderServices(E_commerceDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetAllOrders()
        {
            var Orders= await _context.Orders.Include(c=>c.ShoppingCart).ToListAsync();
            return Orders;
        }
    }
}
