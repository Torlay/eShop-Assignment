using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eShop.View;
using eShop.Service;
using eShop.Service.Interfaces;

namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderServ)
        {
            _orderService = orderServ;
        }

        public IActionResult Index()
        {
            return View(new OrderView());
        }

        [HttpGet]
        public List<OrderView> ListOrderByCustomer(int customerId)
        {
            return _orderService.ListOrders(customerId);
        }

        [HttpPost]
        public bool AddOrder([FromBody] OrderView newOrder)
        {
            return _orderService.AddOrder(newOrder);
        }
    }
}