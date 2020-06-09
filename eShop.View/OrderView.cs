using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.View
{
    public class OrderView
    {
        public int customerId { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<ItemView> Items { get; set; }

        public OrderView() { }

        public OrderView(int customerId, string Description, List<ItemView> Items) 
        {
            this.customerId = customerId;
            this.Description = Description;
            this.Items = Items;
        }

        public OrderView(string description, DateTime createdDate, int customerId)
        {
            this.Description = description;
            this.CreatedDate = createdDate;
            this.customerId = customerId;
        }

    }
}
