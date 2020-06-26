using System;
using Xunit;
using eShop.Entities;

namespace eShop.Test
{
    public class ItemTests
    {

        [Fact]
        public void Should_create_item()
        {
            var newItem = Item.Factory.Create(1, 1, 1.0m);
            Assert.NotNull(newItem);
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        public void Should_not_create_item(int orderid, int amount, decimal price)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Item.Factory.Create(orderid, amount, price));
        }
    }
}
