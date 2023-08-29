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


            public async Task<ActionResult<List<CategoryDTO>>> Index()
            {
                List<CategoryDTO> categories = await _category.GetAllCategories();
                return View(categories);
            }

            public async Task<ActionResult<GetAllCategoryDTO>> Details(int id)
            {
            GetAllCategoryDTO category = await _category.GetCategoryById(id);

                return View(category);
            }

        /*   await _category.Delete(id);
          List<CategoryDTO> categories = await _category.GetAllCategories();
          return View(categories);*/
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            GetAllCategoryDTO category = await _category.GetCategoryById(id);
            await _category.Delete(category.Id);
            CategoryDTO categoryDTO = new CategoryDTO
            {
Name = category.Name,
Id=category.Id
            };
            View(categoryDTO);
            return View();

        }


        public async Task<ActionResult<CategoryDTO>> Edit(int id, CategoryDTO category)
        {
            if (id != category.Id)
            {
                return null;
            }
            if (ModelState.IsValid)
            {
                CategoryDTO updated = await _category.Update(id, category);


                return RedirectToAction(nameof(Index));
            }
            return View();

        }


        public async Task<ActionResult<List<CategoryDTO>>> Create(CategoryDTO category)
        {
            /* var newCat=  await _category.Create(category);
               if (newCat == null)
               {
                   return BadRequest();
               }

               return View(newCat);*/
            if (ModelState.IsValid)
            {
                // Create the new category using _category service
                await _category.Create(category);

                return RedirectToAction(nameof(Index));
            }

            // If model state is invalid, return the view with validation errors
            return View(category);


        }
    }
    }
