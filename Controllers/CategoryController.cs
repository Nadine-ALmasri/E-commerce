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

        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteGet(int id)
        {
            GetAllCategoryDTO category = await _category.GetCategoryById(id);
            CategoryDTO categoryDTO = new CategoryDTO
            {
                Name = category.Name,
                Id = category.Id
            };
            return View(categoryDTO);
        }

        /*   await _category.Delete(id);
          List<CategoryDTO> categories = await _category.GetAllCategories();
          return View(categories);*/
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            GetAllCategoryDTO category = await _category.GetCategoryById(id);
            if(category==null)
                return RedirectToAction(nameof(NotFound));
            await _category.Delete(category.Id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<ActionResult<CategoryDTO>> Edit(int id)
        {
            var category = await _category.GetCategoryById(id);
            var CategoryDTO = new CategoryDTO
            {
                Id=category.Id,
                Name=category.Name
            };
            if(CategoryDTO != null)
            {
                    return View(CategoryDTO);
            }
            return RedirectToAction(nameof(notFound));
        }

        [HttpPost]
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
            return View(category);

        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> Create()
        {
            return View();
        }

        [HttpPost]
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

        public async Task<ActionResult> notFound()
        {
            return View();
        }
    }
    }
