using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using eShop.Entities;

namespace eShop.Service.Repository
{
    internal class CustomerRepository : DBBase<Customer>
    {
        public CustomerRepository() : base() { }

        public override Customer GetInstance(SqlDataReader reader)
        {
            var customerFactory = new Customer.Factory();
            return customerFactory.Create((string)reader[0], (string)reader[1]);
        }

        public List<Customer> ListAll()
        {
            string query = "SELECT name, email FROM Customer";
            return base.Select(query);
        }
    }
}
