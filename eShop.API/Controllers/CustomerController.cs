using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eShop.View;
using eShop.Service;
using eShop.Service.Interfaces;

namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public IActionResult Index()
        {
            return View();
        }

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public List<CustomerView> ListCustomers()
        {
            return _customerService.ListCustomers();
        }
        
        [HttpPost]
        public bool AddCustomer(string name, string email)
        {
            return _customerService.AddCustomer(name, email);
        }
    }
}
