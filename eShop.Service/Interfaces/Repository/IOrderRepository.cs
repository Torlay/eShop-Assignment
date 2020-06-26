using System;
using System.Collections.Generic;
using System.Text;
using eShop.Entities;

namespace eShop.Service.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> ListByCustomer(int customerId);

        int CreateOrder(Order order, int customerId);
    }
}
