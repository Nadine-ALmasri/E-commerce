namespace E_commerce.Models.Interface
{
    public interface ICart
    {
        Task AddToCart(Product product, int Amount);
        Task DeleteProduct(int id);

        Task<Cart> GetCart(string userId);
    }

}
