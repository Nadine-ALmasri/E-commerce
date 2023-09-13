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
        public async Task<ProductCategoryDTO> Create(ProductDTO product)
        {
            var pro = new Product
            {
                Name= product.Name,
                Price= product.Price,
                Description= product.Description,
                CategoryId=product.CategoryId
            };
            _context.Entry(pro).State= EntityState.Added;
            await _context.SaveChangesAsync();
            var productc = await _context.Product.Include(c=>c.Category).FirstOrDefaultAsync(x=>x.Id==pro.Id);

            var productDTO = new ProductCategoryDTO()
            {
                Id = pro.Id,
                Name = pro.Name,
                CategoryId = pro.CategoryId,
                Description = pro.Description,
                Price = pro.Price,
                categoryname = productc.Category.Name,
                ImageUrl = pro.imageUrl // Set the ImageUrl property here
            };
            return productDTO;
        }

        public async Task Delete(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if(product != null)
            {
                _context.Entry(product).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductCategoryDTO>> GetAllProducts()
        {
           var products = await _context.Product.Include(c=>c.Category).Select(pr => new ProductCategoryDTO()
           { 
               Id = pr.Id, 
               Name = pr.Name, 
               CategoryId = pr.CategoryId, 
               Description = pr.Description, 
               Price = pr.Price,
               categoryname=pr.Category.Name
           }).ToListAsync();
            return products;
        }

        public async Task<ProductCategoryDTO> GetProductById(int Id)
        {
            var product=await _context.Product.Include(c=>c.Category).FirstOrDefaultAsync(x=>x.Id==Id);
            if (product == null)
                return null;
            var products = await _context.Product.Select(pr => new ProductCategoryDTO()
            { 
                Id = pr.Id, 
                Name = pr.Name, 
                CategoryId = pr.CategoryId, 
                Description = pr.Description, 
                Price = pr.Price, 
                ImageUrl=pr.imageUrl,
                categoryname=pr.Category.Name
                }).FirstOrDefaultAsync((x => x.Id == Id));
            return products;
        }

        public async Task<ProductDTO> Update(int Id, ProductDTO product)
        {
            var UpdateProduct = await _context.Product.FindAsync(Id);
            if(UpdateProduct != null)
            {
                UpdateProduct.Name=product.Name;
                UpdateProduct.Price=product.Price;
                UpdateProduct.Description=product.Description;
                UpdateProduct.CategoryId = product.CategoryId;
                UpdateProduct.imageUrl = product.ImageUrl;
                _context.Entry(UpdateProduct).State = EntityState.Modified;
                
                await _context.SaveChangesAsync();
            }
            else
            {
                return null;
            }

            var upddateProductDTO = new ProductDTO
            {
                Id = UpdateProduct.Id,
                Name = UpdateProduct.Name,
                Price=UpdateProduct.Price,
                Description=UpdateProduct.Description,
                CategoryId=UpdateProduct.CategoryId
            };
                

            return upddateProductDTO;
        }
    }
}
