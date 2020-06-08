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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;

        public IActionResult Index()
        {
            return View();
        }

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<CustomerView> ListCustomers()
        {
            var customerService = new CustomerService();

            return customerService.ListCustomers();
        }
        
        [HttpPost]
        public bool AddCustomer(string name, string email)
        {
            var customerService = new CustomerService();

            return customerService.AddCustomer(name, email);
        }
    }
}
