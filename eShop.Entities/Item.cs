using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Entities
{
    public class Item
    {
        public int orderId { get; private set; }

        public int Amount { get; private set; }

        public decimal Price { get; private set; }

        private Item(int orderId, int amount, decimal price)
        {
            if (orderId < 1) throw new ArgumentOutOfRangeException("Id must be positive and different than 0.");
            if (amount < 1) throw new ArgumentOutOfRangeException("Amount should be at least 1.");

            this.orderId = orderId;
            this.Amount = amount;
            this.Price = price;
        }

        public class Factory
        {
            public static Item Create(int orderId, int amount, decimal price)
            {
                return new Item(orderId, amount, price);
            }
        }
    }
}
