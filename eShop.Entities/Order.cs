using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.Entities
{
    public class Order
    {
        public int id { get; private set; }

        public string Description { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public Order(string description)
        {
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException("Description must be informed.");

            this.Description = description;
            this.CreatedDate = DateTime.Now;
        }
    }
}
