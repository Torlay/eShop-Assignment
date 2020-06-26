using System;
using Xunit;
using eShop.Entities;

namespace eShop.Test
{
    public class OrderTests
    {
        [Fact]
        public void Should_create_order_description()
        {
            var newOrder = Order.Factory.Create("Description");

            Assert.NotNull(newOrder);
            Assert.NotNull(newOrder.Description);
        }

        [Fact]
        public void Should_create_complete_order()
        {
            int id = 1;
            DateTime date = DateTime.Now;

            var newOrder = Order.Factory.Create(id, "Description", date);

            Assert.NotNull(newOrder);
            Assert.Equal(id, newOrder.id);
            Assert.NotNull(newOrder.Description);
            Assert.Equal(date, newOrder.CreatedDate);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_not_create_order_description(string description)
        {
            Assert.Throws<ArgumentNullException>(() => Order.Factory.Create(description));
        }

        [Theory]
        [InlineData(0, "Desc", 2020, 06, 22)]
        [InlineData(-1, "Desc", 2020, 06, 22)]
        public void Should_not_create_complete_order_id(int id, string description, int year, int month, int day)
        {
            var createdDate = new DateTime(year, month, day);
            Assert.Throws<ArgumentOutOfRangeException>(() => Order.Factory.Create(id, description, createdDate));
        }

        [Theory]
        [InlineData(1, "", 2020, 06, 22)]
        [InlineData(1, " ", 2020, 06, 22)]
        [InlineData(1, null, 2020, 06, 22)]
        public void Should_not_create_complete_order_description(int id, string description, int year, int month, int day)
        {
            var createdDate = new DateTime(year, month, day);
            Assert.Throws<ArgumentNullException>(() => Order.Factory.Create(id, description, createdDate));
        }
    }
}
