using System;
using System.Collections.Generic;
using System.Text;
using eShop.Entities;

namespace eShop.Service.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetItemsByOrder(int orderId);

        void CreateItemForOrder(Item item);
    }
}
