using E_commerce.Models.DTOs;

namespace E_commerce.Models.Interface
{
    public interface ICategory
    {

        Task<CategoryDTO> Create(Category category);
        Task<List<GetAllCategoryDTO>> GetAllCategories();
        Task<GetAllCategoryDTO> GetCategoryById(int id);
        Task<Category> Update(int id, CategoryDTO category);
        Task Delete(int id);
    }
}
