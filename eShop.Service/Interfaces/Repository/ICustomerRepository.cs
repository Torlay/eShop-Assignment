using System;
using System.Collections.Generic;
using System.Text;
using eShop.Entities;

namespace eShop.Service.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> ListAll();

        int Insert(Customer newCustomer);
    }
}
