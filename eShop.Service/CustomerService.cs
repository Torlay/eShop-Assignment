using System;
using System.Collections.Generic;
using System.Text;
using eShop.View;
using eShop.Entities;
using eShop.Service.Repository;
using eShop.Service.Interfaces;

namespace eShop.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _repo = customerRepo;
        }

        public List<CustomerView> ListCustomers()
        {
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
            var newCustomer = Customer.Factory.Create(name, email);

            _repo.Insert(newCustomer);

            return true;
        }
    }
}
