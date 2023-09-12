using E_commerce.Models;
using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace E_commerce.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProduct _prouduct;
        private readonly ICategory _category;

        public ProductController(IProduct prouduct, ICategory category)
        {
            _prouduct = prouduct;
            _category = category;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductCategoryDTO> products = await _prouduct.GetAllProducts();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            ProductCategoryDTO product = await _prouduct.GetProductById(id);

            return View(product);
        }
        [Authorize(Roles = "Administrator,Editor")]
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            if(id != 0)
            {
                var category = await _category.GetCategoryById(id);
                ViewBag.CategoryID = category.Id;
                ViewBag.CategoryName = category.Name;
            }
            var CategoriesDTO = await _category.GetAllCategories();
            ViewBag.CategoriesDTO = new SelectList(CategoriesDTO, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Editor")]
        public async Task<IActionResult> Create(int id,ProductDTO product)
        {
            if(id!=0)
            {
                var category = await _category.GetCategoryById(id);
                ViewBag.CategoryID = category.Id;
                ViewBag.CategoryName = category.Name;
            }
            ProductCategoryDTO result = null;
            if (ModelState.IsValid)
            {
                // Create the new category using _category service
                result=await _prouduct.Create(product);
                var categoryResult = await _category.GetCategoryById(result.CategoryId);
                return RedirectToAction(nameof(Details),"Category", categoryResult);
            }

            List<CategoryDTO> CategoriesDTO;

            if ( result==null)
            {
                CategoriesDTO = await _category.GetAllCategories();
                ViewBag.CategoriesDTO = new SelectList(CategoriesDTO, "Id", "Name");

                // If model state is invalid, return the view with validation errors
                return View();
            }
           
            var productCategoryDTO = new ProductCategoryDTO
            { 
            CategoryId = result.CategoryId ,
            Price = result.Price ,
            Name = result.Name ,
            Description = result.Description ,
            Id = result.Id 
            };
            CategoriesDTO = await _category.GetAllCategories();
            ViewBag.CategoriesDTO = new SelectList(CategoriesDTO, "Id", "Name");

            // If model state is invalid, return the view with validation errors
            return View(productCategoryDTO);
        }

        [HttpGet]
        [ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteGet(int id)
        {
            var product = await _prouduct.GetProductById(id);
            return View(product);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            ProductCategoryDTO product = await _prouduct.GetProductById(id);
            if(product==null)
                return RedirectToAction("notFound", "Home");
            var category = await _category.GetCategoryById(product.CategoryId);
            await _prouduct.Delete(product.Id);
            return RedirectToAction(nameof(Details), "Category", category);
        }
        [HttpGet]
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Edit(int id)
        {   

            var Product = await _prouduct.GetProductById(id);
            var CategoriesDTO = await _category.GetAllCategories();
            ViewBag.CategoriesDTO = new SelectList(CategoriesDTO, "Id", "Name");
            var ProductDTO = new ProductDTO
            {
                Id = Product.Id,
                Name= Product.Name,
                Price= Product.Price,
                Description= Product.Description,
                CategoryId= Product.CategoryId
            };
            if (ProductDTO != null)
            {
                return View(ProductDTO);
            }
            return RedirectToAction("notFound", "Home");
        }



        [HttpPost]
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> Edit(int id, ProductDTO product)
        {
            if (id != product.Id)
            {
                return RedirectToAction("notFound", "Home");
            }
            if (ModelState.IsValid)
            {
                var updated = await _prouduct.Update(id, product);
                var category = await _category.GetCategoryById(updated.CategoryId);
                var updatedDTO = new ProductCategoryDTO
                {
                    Id= updated.Id,
                    Name= updated.Name,
                    Price= updated.Price,
                    Description = updated.Description,
                    CategoryId = updated.CategoryId,
                    categoryname= category.Name
                };
                return RedirectToAction(nameof(Details), updatedDTO);
            }
            var CategoriesDTO = await _category.GetAllCategories();
            ViewBag.CategoriesDTO = new SelectList(CategoriesDTO, "Id", "Name");
            return View(product);
        }
    }
}

