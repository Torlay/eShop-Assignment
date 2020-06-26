using System;
using System.Collections.Generic;
using System.Text;
using eShop.View;

namespace eShop.Service.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerView> ListCustomers();
        
        bool AddCustomer(string name, string email);
    }
}
