using eShop.Entities;
using eShop.View;
using System;
using System.Collections.Generic;
using System.Text;
using eShop.Service.Repository;

namespace eShop.Service
{
    public class ItemService
    {
        private ItemRepository _repo;

        internal List<ItemView> GetItemsByOrder(int id)
        {
            _repo = new ItemRepository();
            var items = _repo.GetItemsByOrder(id);

            List<ItemView> result = new List<ItemView>(items.Count);

            foreach (Item i in items)
            {
                result.Add(new ItemView(i.Amount, i.Price));
            }

            return result;
        }
    }
}
