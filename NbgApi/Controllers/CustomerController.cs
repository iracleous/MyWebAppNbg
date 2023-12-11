using DomainProject.Models;
using DomainProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NbgApi.Services;

namespace NbgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _services;
        private readonly IProductServices _productServices;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerServices services,
            IProductServices productServices,
            ILogger<CustomerController> logger)
        {
            _services = services;
            _productServices = productServices;
            _logger = logger;
        }


        [HttpGet]
        [Route("c")]
        public List<Customer> GetAllCustomers()
        {
            _logger.Log(LogLevel.Information, "Getting all customers");
           return [.. _services.GetCustomers()] ;
           
        }

        [HttpPost]
        [Route("c")]
        public Customer? CreateCustomer(Customer customer)
        {
            _logger.Log(LogLevel.Information, "Creating a new customer");
            return _services.CreateCustomer(customer);

        }




        [HttpGet]
        [Route("{id}")]
        public Customer? GetById([FromRoute]int id)
        {
            _logger.Log(LogLevel.Information, "Getting all customers");
            return _services.GetCustomerById(id);
        }


        [HttpGet]
        [Route("p")]
        public List<Product> GetAllProducts()
        {
            _logger.Log(LogLevel.Information, "Getting all customers");
            return [.. _productServices.GetProducts()];
        }



    }
}
