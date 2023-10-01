using E_commerce.Models.DTOs;

namespace E_commerce.Models.Interface
{
    public interface ICart
    {
        Task<List<CartProducts>> AddToCart(ProductCategoryDTO product);
        Task DeleteProduct(int id);
        Task LessQuantity(int id);





    }

}
