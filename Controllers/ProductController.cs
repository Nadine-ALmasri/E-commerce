using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using E_commerce.Models;
using E_commerce.Models.DTOs;
using E_commerce.Models.Interface;
using E_commerce.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection.Metadata;
using static System.Reflection.Metadata.BlobBuilder;

namespace E_commerce.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProduct _prouduct;
        private readonly ICategory _category;
        private readonly IConfiguration _configuration;

        public ProductController(IProduct prouduct, ICategory category, IConfiguration configuration)
        {
            _prouduct = prouduct;
            _category = category;
            _configuration = configuration;
        }
        [Authorize(Roles = "Administrator,Editor,User")]
        public async Task<IActionResult> Index()
        {
            List<ProductCategoryDTO> products = await _prouduct.GetAllProducts();
            return View(products);
        }
        [Authorize(Roles = "Administrator,Editor,User")]
        public async Task<IActionResult> Details(int id)
        {
            ProductCategoryDTO product = await _prouduct.GetProductById(id);

            return View(product);
        }
        [Authorize(Roles = "Administrator,Editor")]
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            if (id != 0)
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
        public async Task<IActionResult> Create(int id, ProductDTO product)
        {
            if (id != 0)
            {
                var category = await _category.GetCategoryById(id);
                ViewBag.CategoryID = category.Id;
                ViewBag.CategoryName = category.Name;
            }
            ProductCategoryDTO result = null;
            if (ModelState.IsValid)
            {
                // Create the new category using _category service
                result = await _prouduct.Create(product);
                var categoryResult = await _category.GetCategoryById(result.CategoryId);
                return RedirectToAction(nameof(Details), "Category", categoryResult);
            }

            List<CategoryDTO> CategoriesDTO;

            if (result == null)
            {
                CategoriesDTO = await _category.GetAllCategories();
                ViewBag.CategoriesDTO = new SelectList(CategoriesDTO, "Id", "Name");

                // If model state is invalid, return the view with validation errors
                return View();
            }

            var productCategoryDTO = new ProductCategoryDTO
            {
                CategoryId = result.CategoryId,
                Price = result.Price,
                Name = result.Name,
                Description = result.Description,
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
            if (product == null)
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
                Name = Product.Name,
                Price = Product.Price,
                Description = Product.Description,
                CategoryId = Product.CategoryId,
                ImageUrl = Product.ImageUrl,
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
                    Id = updated.Id,
                    Name = updated.Name,
                    Price = updated.Price,
                    Description = updated.Description,
                    CategoryId = updated.CategoryId,
                    categoryname = category.Name,
                    ImageUrl = updated.ImageUrl,
                };
                return RedirectToAction(nameof(Details), updatedDTO);
            }
            var CategoriesDTO = await _category.GetAllCategories();
            ViewBag.CategoriesDTO = new SelectList(CategoriesDTO, "Id", "Name");
            return View(product);
        }

        [Authorize(Roles = "Editor")]
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, int productId)
        {
            // Add some logging to check the value of productName
            var product = await _prouduct.GetProductById(productId);

            if (file != null && file.Length > 0)
            {
                // Upload the file to Azure Blob Storage
                string containerName = "images"; // Replace with your container name
                string blobName = $"{product.Id}/{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}"; // Use a unique file name

                BlobContainerClient blobContainerClient =
                               new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), containerName);

                BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

                string contentType = GetContentType(Path.GetExtension(file.FileName));

                BlobHttpHeaders blobHttpHeaders = new BlobHttpHeaders
                {
                    ContentType = file.ContentType // Set the content type from the uploaded file
                };

                using (var stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }

                // Set the product's image URL



                product.ImageUrl = GetAzureBlobStorageImageUrl(containerName, blobName);
                if (product != null)
                {
                    ProductDTO newpro = new ProductDTO()
                    {
                        CategoryId = product.CategoryId,

                        Description = product.Description,
                        ImageUrl = product.ImageUrl,
                        Name = product.Name,
                        Price = product.Price
                    ,
                        Id = product.Id
                    };

                    await _prouduct.Update(newpro.Id, newpro);
                }


                return RedirectToAction(nameof(Details), new { id = productId });
            }

            return RedirectToAction("notFound", "Home");
        }





        private string GetAzureBlobStorageImageUrl(string containerName, string blobName)
        {
            // Get the Azure Blob Storage account name from configuration
            string storageEndpoint = $"https://imagesforproducts.blob.core.windows.net";
            return $"{storageEndpoint}/{containerName}/{blobName}";

            // Combine the base URL, container name, and blob name to create the image URL

        }
        private string GetContentType(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                // Add more cases for other image formats as needed
                default:
                    return "application/octet-stream"; // Default to binary data if format is unknown
            }
        }

        public IActionResult AddToCart(int productId, int quantity)
        {


            return null; // Redirect to the Cart page.
        }
    }
}


