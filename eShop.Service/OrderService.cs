using System;
using System.Collections.Generic;
using System.Text;
using eShop.View;
using eShop.Entities;
using eShop.Service.Repository;
using eShop.Service.Interfaces;

namespace eShop.Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _repo;
        private IItemService _itemServ;

        public OrderService(IOrderRepository orderRepo, IItemService itemServ)
        {
            _repo = orderRepo;
            _itemServ = itemServ;
        }

        public List<OrderView> ListOrders(int customerId)
        {
            var orders = _repo.ListByCustomer(customerId);

            List<OrderView> result = new List<OrderView>(orders.Count);

            foreach (Order o in orders)
            {
                var ov = new OrderView(o.Description, o.CreatedDate, customerId);

                ov.Items = _itemServ.GetItemsByOrder(o.id);

                result.Add(ov);
            }

            return result;
        }

        public bool AddOrder(OrderView newOrder)
        {
            if (newOrder.customerId < 1) return false;

            var order = Order.Factory.Create(newOrder.Description);

            int newOrderId = _repo.CreateOrder(order, newOrder.customerId);

            if (newOrderId > 0)
            {
                foreach(ItemView iv in newOrder.Items)
                {
                    var item = Item.Factory.Create(newOrderId, iv.Amount, iv.Price);
                    _itemServ.AddItem(item);
                }
            }
            return newOrderId > 0;
        }
    }
}
