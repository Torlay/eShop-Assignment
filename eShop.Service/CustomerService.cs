using System;
using System.Collections.Generic;
using System.Text;
using eShop.View;
using eShop.Entities;
using eShop.Service.Repository;

namespace eShop.Service
{
    public class CustomerService
    {
        private CustomerRepository _repo;

        public List<CustomerView> ListCustomers()
        {
            _repo = new CustomerRepository();
            var customers = _repo.ListAll();
            List<CustomerView> result = new List<CustomerView>(customers.Count);

            foreach(Customer c in customers)
            {
                result.Add(new CustomerView(c.Name, c.Email));
            }
            
            return result;
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
