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
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerServices services, ILogger<CustomerController> logger)
        {
            _services = services;
            _logger = logger;
        }

        
        [HttpGet]
        public List<Customer> GetAll()
        {
            _logger.Log(LogLevel.Information, "Getting all customers");
            return _services.GetCustomers().ToList();
        }
      /*  */

        [HttpGet]
        [Route("{id}")]
        public Customer? GetById([FromRoute]int id)
        {
            _logger.Log(LogLevel.Information, "Getting all customers");
            return _services.GetCustomerById(id);
        }

    }
}
