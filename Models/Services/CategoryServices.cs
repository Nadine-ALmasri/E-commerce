
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
        public async Task<CategoryDTO> Create(Category category)
        {
            _context.Entry(category).State = EntityState.Added;

            await _context.SaveChangesAsync();

            CategoryDTO categorydto = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name
            };

            return categorydto;

        }

        public async Task Delete(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            _context.Entry(category).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetAllCategoryDTO>> GetAllCategories()
        {
            var TheCategory= await _context.Categories.Select(category => new GetAllCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    CategoryId = p.CategoryId

                }).ToList()
            }).ToListAsync();
            return TheCategory;

        }

        public async Task<GetAllCategoryDTO> GetCategoryById(int id)
        {
           var TheCategory=  await _context.Categories.Select(category => new GetAllCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.Select(p => new Product
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

        public async Task<Category> Update(int id, CategoryDTO category)
        {
            Category UpdatedCategory = await _context.Categories.FindAsync(id);
            if (UpdatedCategory != null)
            {
                UpdatedCategory.Name = category.Name;
                UpdatedCategory.Id = category.Id;
                _context.Entry(UpdatedCategory).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return UpdatedCategory;

        }
    }
}
