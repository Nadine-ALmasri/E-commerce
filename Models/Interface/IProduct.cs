using E_commerce.Models.DTOs;

namespace E_commerce.Models.Interface
{
    public interface IProduct
    {

        Task<ProductDTO> Create(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int Id);
        Task<ProductDTO> Update(int Id, Product product);
        Task Delete(int id);
    }
}
