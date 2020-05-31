using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Entities
{
    public class Item
    {
        public int id { get; private set; }

        public int Amount { get; private set; }

        public float Price { get; private set; }

        public Item(int amount, float price)
        {
            if (amount < 1) throw new ArgumentOutOfRangeException("Amount should be at least 1.");

            this.Amount = amount;
            this.Price = price;
        }
    }
}
