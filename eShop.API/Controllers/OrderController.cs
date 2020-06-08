using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eShop.View;
using eShop.Service;
using eShop.Entities;

namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<OrderView> ListOrderByCustomer(int customerId)
        {
            var orderService = new OrderService();

            return orderService.ListOrders(customerId);
        }

        [HttpPost]
        public bool AddOrder([FromBody] OrderView newOrder)
        {
            var orderService = new OrderService();

            return orderService.AddOrder(newOrder);
        }
    }
}