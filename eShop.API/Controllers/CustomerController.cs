using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eShop.View;
using eShop.Service;

namespace eShop.API.Controllers
{   
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("customer/list")]
        public List<CustomerView> ListCustomers()
        {
            var customerService = new CustomerService();

            return customerService.ListCustomers();
        }

        [HttpPost("customer/add")]
        public bool AddCustomer(string name, string email)
        {
            var customerService = new CustomerService();

            return customerService.AddCustomer(name, email);
        }
    }
}
