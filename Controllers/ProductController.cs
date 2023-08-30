using E_commerce.Models;
using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProduct _prouduct;

        public ProductController(IProduct prouduct)
        {
            _prouduct = prouduct;
        }

        public async Task<ActionResult<ProductCategoryDTO>> Index()
        {
            List<ProductCategoryDTO> products = await _prouduct.GetAllProducts();
            return View(products);
        }

        public async Task<ActionResult<ProductCategoryDTO>> Details(int id)
        {
            ProductCategoryDTO product = await _prouduct.GetProductById(id);

            return View(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCategoryDTO>>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductCategoryDTO>>> Create(ProductDTO product)
        {
            ProductCategoryDTO result = null;
            if (ModelState.IsValid)
            {
                // Create the new category using _category service
                result=await _prouduct.Create(product);

                return RedirectToAction(nameof(Index));
            }
           
            var productCategoryDTO = new ProductCategoryDTO
            { 
            CategoryId = result.CategoryId ,
            Price = result.Price ,
            Name = result.Name ,
            Description = result.Description ,
            Id = result.Id 
            };

            // If model state is invalid, return the view with validation errors
            return View(productCategoryDTO);
        }
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            ProductCategoryDTO product = await _prouduct.GetProductById(id);
            await _prouduct.Delete(product.Id);
            ProductDTO newPro = new ProductDTO
            {
Name= product.Name ,
Description= product.Description ,
Id = product.Id,
Price = product.Price ,
CategoryId = product.CategoryId ,

            };
            View(newPro);
            return View();

        }
        public async Task<ActionResult<ProductDTO>> Edit(int id, ProductDTO product)
        {
            if (id !=product.Id)
            {
                return null;
            }
            if (ModelState.IsValid)
            {
                ProductDTO updated = await _prouduct.Update(id, product);


                return RedirectToAction(nameof(Index));
            }
            return View();

        }
    }
}

