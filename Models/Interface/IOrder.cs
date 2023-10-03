using E_commerce.Models.DTOs;

namespace E_commerce.Models.Interface
{
    public interface IOrder
    {
        public Task<List<Order>> GetAllOrders();
    }
}
