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

        public Order(string description, DateTime createdDate)
        {
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException("Description must be informed.");
            if (createdDate == null) throw new ArgumentNullException("CreatedDate must be informed.");

            this.Description = description;
            this.CreatedDate = createdDate;
        }

        public Order(int id, string description, DateTime createdDate)
        {
            if (id < 1) throw new ArgumentOutOfRangeException("Id must be positive and different than 0.");
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException("Description must be informed.");
            if (createdDate == null) throw new ArgumentNullException("CreatedDate must be informed.");

            this.id = id;
            this.Description = description;
            this.CreatedDate = createdDate;
        }

        public class Factory
        {
            public Order Create(int id, string description, DateTime createdDate)
            {
                return new Order(id, description, createdDate);
            }

            public Order Create(string description, DateTime createdDate)
            {
                return new Order(description, createdDate);
            }

            public Order Create(string description)
            {
                return new Order(description);
            }
        }
    }
}
