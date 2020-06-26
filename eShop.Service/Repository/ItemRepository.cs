using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using eShop.Entities;
using eShop.Service.Interfaces;

namespace eShop.Service.Repository
{
    public class ItemRepository : DBBase<Item>, IItemRepository
    {
        internal override Item GetInstance(SqlDataReader reader)
        {
            return Item.Factory.Create((int)reader[0], (int)reader[1], (decimal)reader[2]);
        }

        public List<Item> GetItemsByOrder(int orderId)
        {
            string query = $"SELECT orderId, amount, price from [Item] where orderId = '{orderId}'";
            return base.Select(query);
        }

        public void CreateItemForOrder(Item item)
        {
            string command = $"INSERT INTO [Item] VALUES ({item.orderId}, {item.Amount}, {item.Price})";
            base.ExecuteCommand(command);
        }
    }
}
