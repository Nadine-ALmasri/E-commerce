using E_commerce.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;


        public OrderController(IOrder order)
        {
            _order = order;
        }/// <summary>
        /// to get all the orders
        /// </summary>
        /// <returns></returns>

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            var Order=await _order.GetAllOrders();
            return View(Order);
        }
    }
}
