using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using eShop.Entities;

namespace eShop.Service.Repository
{
    internal class ItemRepository : DBBase<Item>
    {
        internal override Item GetInstance(SqlDataReader reader)
        {
            var itemFactory = new Item.Factory();
            return itemFactory.Create((int)reader[0], (int)reader[1], (decimal)reader[2]);
        }

        internal List<Item> GetItemsByOrder(int orderId)
        {
            string query = $"SELECT orderId, amount, price from [Item] where orderId = '{orderId}'";
            return base.Select(query);
        }

        internal void CreateItemForOrder(Item item)
        {
            string command = $"INSERT INTO [Item] VALUES ({item.orderId}, {item.Amount}, {item.Price})";
            base.ExecuteCommand(command);
        }
    }
}
