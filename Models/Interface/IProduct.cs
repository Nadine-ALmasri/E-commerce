using E_commerce.Models.DTOs;

namespace E_commerce.Models.Interface
{
    public interface IProduct
    {

        Task<ProductCategoryDTO> Create(ProductDTO product);
        Task<List<ProductCategoryDTO>> GetAllProducts();
        Task<ProductCategoryDTO> GetProductById(int Id);
        Task<ProductDTO> Update(int Id, ProductDTO product);
        Task Delete(int id);
    }
}
