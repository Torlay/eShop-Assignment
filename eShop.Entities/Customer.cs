using System;

namespace eShop.Entities
{
    public class Customer
    {
        public int id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        private Customer() { }

        private Customer(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Name must be informed.");
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException("Email must be informed.");

            this.Name = name;
            this.Email = email;
        }

        public class Factory
        {
            public static Customer Create(string name, string email)
            {
                return new Customer(name, email);
            }
        }
    }
}
