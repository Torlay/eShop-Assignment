using System;
using Xunit;
using eShop.Entities;

namespace eShop.Test
{
    public class CustomerTests
    {
        [Fact]
        public void Should_create_valid_customer()
        {
            var newCustomer = Customer.Factory.Create("Raphael", "teste@teste");

            Assert.NotNull(newCustomer);
            Assert.NotNull(newCustomer.Name);
            Assert.NotNull(newCustomer.Email);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("Raphael", "")]
        [InlineData("", "teste@teste")]
        [InlineData("Raphael", null)]
        [InlineData(null, "teste@teste")]
        [InlineData(null, null)]
        public void Should_not_create_customer(string name, string email) 
        {
            Assert.Throws<ArgumentNullException>(() => Customer.Factory.Create(name, email));
        }
    }
}
