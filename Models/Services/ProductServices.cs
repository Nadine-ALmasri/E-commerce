using E_commerce.Data;
using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Models.Services
{
    public class ProductServices : IProduct
    {
        private readonly E_commerceDbContext _context;
        public ProductServices(E_commerceDbContext context)
        {
            _context = context;

        }
        public async Task<ProductDTO> Create(Product product)
        {
        _context.Entry(product).State= EntityState.Added;

            await _context.SaveChangesAsync();
            ProductDTO productDTO = new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Price = product.Price,


            };
            return productDTO;
        }

        public async Task Delete(int id)
        {
            Product product = await _context.Product.FindAsync(id);
            _context.Entry(product ).State= EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
           var products = await _context.Product.Select(pr => new Product()
           { Id = pr.Id, Name = pr.Name, CategoryId = pr.CategoryId, Description = pr.Description, Price = pr.Price }).ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int Id)
        {
            var products = await _context.Product.Select(pr => new Product()
            { Id = pr.Id, Name = pr.Name, CategoryId = pr.CategoryId, Description = pr.Description, Price = pr.Price }).FirstOrDefaultAsync((x => x.Id == Id));
            return products;
        }

        public async Task<ProductDTO> Update(int Id, Product product)
        {
            ProductDTO productDto = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };
                _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 

            return productDto;
        }
    }
}
