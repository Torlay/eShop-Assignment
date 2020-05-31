using eShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Service
{
    public class ItemService
    {
        public Item GetItem(int itemId)
        {
            return new Item(1, 10.0f);
        }
    }
}
