
using E_commerce.Data;
using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Models.Services
{
    public class CategoryServices : ICategory
    {
        private readonly E_commerceDbContext _context;
        public CategoryServices(E_commerceDbContext context)
        {
            _context = context;

        }
        /// <summary>
        /// this method is to create new category 
        /// </summary>
        /// <param name="category"></param>
        /// <returns>CategoryDTO</returns>
        public async Task<CategoryDTO> Create(CategoryDTO category)
        {
            var newCategory = new Category
            {
                Name=category.Name
            };

            _context.Entry(newCategory).State = EntityState.Added;

            await _context.SaveChangesAsync();

            var categorydto = new CategoryDTO()
            {
                Id = newCategory.Id,
                Name = newCategory.Name
            };

            return categorydto;

        }
        /// <summary>
        /// this method is to delete a category 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            _context.Entry(category).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// this methode is to get all the categories
        /// </summary>
        /// <returns>List<CategoryDTO></returns>
        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            var TheCategory= await _context.Categories.Select(category => new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
            }).ToListAsync();
            return TheCategory;

        }
        /// <summary>
        /// / this methode is to get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> spasafic category</returns>
        public async Task<GetAllCategoryDTO> GetCategoryById(int id)
        {
           var TheCategory=  await _context.Categories.Select(category => new GetAllCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    CategoryId = p.CategoryId
                }).ToList()
            }).FirstOrDefaultAsync(a => a.Id == id);
            return TheCategory;
        }
        /// <summary>
        /// this method is to update the data for a spacifc category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns>CategoryDTO</returns>
        public async Task<CategoryDTO> Update(int id, CategoryDTO category)
        {
            var UpdatedCategory = await _context.Categories.FindAsync(id);
            
            if (UpdatedCategory != null)
            {
                UpdatedCategory.Name = category.Name;
                _context.Entry(UpdatedCategory).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return null;
            }

            var UpdatedCategoryDTO = new CategoryDTO
            {
                Id= UpdatedCategory.Id,
                Name = UpdatedCategory.Name
            };

            return UpdatedCategoryDTO;

        }
    }
}
