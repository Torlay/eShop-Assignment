using eShop.Entities;
using eShop.View;
using System;
using System.Collections.Generic;
using System.Text;
using eShop.Service.Repository;
using eShop.Service.Interfaces;

namespace eShop.Service
{
    public class ItemService : IItemService
    {
        private IItemRepository _repo;

        public ItemService(IItemRepository itemRepo)
        {
            _repo = itemRepo;
        }

        public List<ItemView> GetItemsByOrder(int id)
        {
            var items = _repo.GetItemsByOrder(id);

            List<ItemView> result = new List<ItemView>(items.Count);

            foreach (Item i in items)
            {
                result.Add(new ItemView(i.Amount, i.Price));
            }

            return result;
        }

        public void AddItem(Item newItem)
        {
            _repo.CreateItemForOrder(newItem);
        }
    }
}
