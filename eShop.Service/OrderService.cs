using System;
using System.Collections.Generic;
using System.Text;
using eShop.View;
using eShop.Entities;

namespace eShop.Service
{
    public class OrderService
    {
        public List<OrderView> ListOrders(int customerId)
        {
            return new List<OrderView>()
            {
                new OrderView("Order 1"),
                new OrderView("Order 2")
            };
        }

        public bool AddOrder(int customerId, string description)
        {
            return true;
        }

        public bool AddItem(Item item, int orderId)
        {
            return true;
        }

        public OrderView FindOrder(int orderId)
        {
            var order = new OrderView($"Order {orderId}");
            order.Items = new List<ItemView>()
            {
                new ItemView(1, 10.0f),
                new ItemView(2, 13.33f),
            };

            return order;
        }
    }
}
