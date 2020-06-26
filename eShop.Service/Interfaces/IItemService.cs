using System;
using System.Collections.Generic;
using System.Text;
using eShop.View;
using eShop.Entities;

namespace eShop.Service.Interfaces
{
    public interface IItemService
    {
        List<ItemView> GetItemsByOrder(int id);

        void AddItem(Item newItem);
    }
}
