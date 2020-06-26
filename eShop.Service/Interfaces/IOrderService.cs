using System;
using System.Collections.Generic;
using System.Text;
using eShop.View;

namespace eShop.Service.Interfaces
{
    public interface IOrderService
    {
        List<OrderView> ListOrders(int customerId);
        
        bool AddOrder(OrderView newOrder);
    }
}
