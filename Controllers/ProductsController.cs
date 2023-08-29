using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Models.Interface;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public class ProductController : Controller
        {
            private readonly IProduct _prouduct;

            public ProductController(IProduct prouduct)
            {
                _prouduct = prouduct;
            }


            // GET: api/Products
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
            {

                return Ok(_prouduct.GetAllProducts());
            }

            // GET: api/Products/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Product>> GetProduct(int id)
            {


                return Ok(await _prouduct.GetProductById(id));
            }

            // PUT: api/Products/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutProduct(int id, Product product)
            {
                var updatedProduct = await _prouduct.Update(id, product);
                return Ok(updatedProduct);
            }

            // POST: api/Products
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Product>> PostProduct(Product product)
            {
                if (_context.Product == null)
                {
                    return Problem("Entity set 'E_commerceDbContext.Product'  is null.");
                }
                _context.Product.Add(product);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }

            // DELETE: api/Products/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProduct(int id)
            {
                if (_context.Product == null)
                {
                    return NotFound();
                }
                var product = await _context.Product.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                _context.Product.Remove(product);
                await _context.SaveChangesAsync();

                return NoContent();
            }



        }
    }
}
