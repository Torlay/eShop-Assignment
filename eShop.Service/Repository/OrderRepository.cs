using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using eShop.Entities;

namespace eShop.Service.Repository
{
    internal class OrderRepository : DBBase<Order>
    {
        internal override Order GetInstance(SqlDataReader reader)
        {
            var orderFactory = new Order.Factory();
            return orderFactory.Create((int)reader[0], (string)reader[1], (DateTime)reader[2]);
        }

        internal List<Order> ListByCustomer(int customerId)
        {
            string query = $"SELECT id, description, createdDate, customerId FROM [Order] where customerId = '{customerId}'";
            return base.Select(query);
        }

        internal int CreateOrder(Order order, int customerId)
        {
            string command = $"INSERT INTO [Order] OUTPUT Inserted.id VALUES ('{order.Description}', '{order.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss")}', {customerId})";

            return base.ExecuteCommand(command);
        }
    }
}
