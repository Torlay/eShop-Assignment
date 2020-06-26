using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using eShop.Entities;
using eShop.Service.Interfaces;

namespace eShop.Service.Repository
{
    public class CustomerRepository : DBBase<Customer>, ICustomerRepository
    {
        internal override Customer GetInstance(SqlDataReader reader)
        {
            return Customer.Factory.Create((string)reader[0], (string)reader[1]);
        }

        public List<Customer> ListAll()
        {
            string query = "SELECT name, email FROM Customer";
            return base.Select(query);
        }

        public int Insert(Customer newCustomer)
        {
            string command = $"INSERT INTO Customer VALUES ('{newCustomer.Name}', '{newCustomer.Email}')";
            return base.ExecuteCommand(command);
        }
    }
}
