using E_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_commerce.Controllers
{
    public class HomeController : Controller
    {
      
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        public async Task<IActionResult> notFound()
        {
            return View();
        }
    }
    }