using System;
using System.Collections.Generic;
using System.Text;
using eShop.View;
using eShop.Entities;

namespace eShop.Service
{
    public class CustomerService
    {
        public List<CustomerView> ListCustomers()
        {
            return new List<CustomerView>()
            {
                new CustomerView("Raphael","raphael@sovos.com"),
                new CustomerView("Thiago","thiago@sovos.com")
            };
        }

        public bool AddCustomer(string name, string email)
        {
            var factory = new Customer.Factory();
            var newCustomer = factory.Create(name, email);

            //persist new customer

            return true;
        }
    }
}
