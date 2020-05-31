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

        public OrderView(string description)
        {
            this.Description = description;
            this.CreatedDate = DateTime.Now;
        }

    }
}
