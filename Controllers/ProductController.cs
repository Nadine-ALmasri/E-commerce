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

            public async Task<ActionResult<Product>> Index()
            {
                List<Product> products = await _prouduct.GetAllProducts();
                return View(products);
            }

            public async Task<ActionResult<Product>> Details(int id)
            {
                Product product = await _prouduct.GetProductById(id);

                return View(product);
            }
        }
    }

