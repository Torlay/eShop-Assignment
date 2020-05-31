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
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet("order/list")]
        public List<OrderView> ListOrderByCustomer(int customerId)
        {
            var orderService = new OrderService();

            return orderService.ListOrders(customerId);
        }

        [HttpGet("order/find")]
        public OrderView FindOrder(int orderId)
        {
            var orderService = new OrderService();

            return orderService.FindOrder(orderId);
        }

        [HttpPost("order/add")]
        public bool AddOrder(int customerId, string description)
        {
            var orderService = new OrderService();

            return orderService.AddOrder(customerId, description);
        }

        [HttpPost("order/addItem")]
        public bool AddItem (int itemId, int orderId)
        {
            var itemService = new ItemService();
            var orderService = new OrderService();

            Item item = itemService.GetItem(itemId);

            return orderService.AddItem(item, orderId);
        }
    }
}