using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.View
{
    public class ItemView
    {
        public int Amount { get; set; }

        public float Price { get; set; }

        public ItemView(int amount, float price)
        {
            this.Amount = amount;
            this.Price = price;
        }
    }
}
