using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.View
{
    public class CustomerView
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public CustomerView(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}
