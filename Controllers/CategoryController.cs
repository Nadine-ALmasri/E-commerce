using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class CategoryController : Controller
    {
        
            private readonly ICategory _category;

            public CategoryController(ICategory category)
            {
                _category = category;
            }


            public async Task<ActionResult<CategoryDTO>> Index()
            {
                List<GetAllCategoryDTO> categories = await _category.GetAllCategories();
                return View(categories);
            }

            public async Task<ActionResult<CategoryDTO>> Details(int id)
            {
            GetAllCategoryDTO category = await _category.GetCategoryById(id);

                return View(category);
            }
        }
    }
