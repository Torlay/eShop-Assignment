using System;
using System.Collections.Generic;
using System.Text;
using eShop.View;
using eShop.Entities;
using eShop.Service.Repository;

namespace eShop.Service
{
    public class OrderService
    {
        private OrderRepository _repo;

        public List<OrderView> ListOrders(int customerId)
        {
            _repo = new OrderRepository();
            var orders = _repo.ListByCustomer(customerId);

            List<OrderView> result = new List<OrderView>(orders.Count);

            var itemServ = new ItemService();

            foreach (Order o in orders)
            {
                var ov = new OrderView(o.Description, o.CreatedDate, customerId);

                ov.Items = itemServ.GetItemsByOrder(o.id);

                result.Add(ov);
            }

            return result;
        }

        public bool AddOrder(OrderView newOrder)
        {
            if (newOrder.customerId < 1) return false;

            _repo = new OrderRepository();
            var orderFactory = new Order.Factory();
            var order = orderFactory.Create(newOrder.Description);

            int newOrderId = _repo.CreateOrder(order, newOrder.customerId);

            if (newOrderId > 0)
            {
                var itemFactory = new Item.Factory();
                var itemRepo = new ItemRepository();
                foreach(ItemView iv in newOrder.Items)
                {
                    var item = itemFactory.Create(newOrderId, iv.Amount, iv.Price);
                    itemRepo.CreateItemForOrder(item);
                }
            }
            return newOrderId > 0;
        }
    }
}
