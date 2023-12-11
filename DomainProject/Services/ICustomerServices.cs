using DomainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Services
{
    public interface ICustomerServices
    {
        public Customer? CreateCustomer(Customer customer);
        public List<Customer>  GetCustomers();
        public Customer? GetCustomerById(int customerId); 
        public Customer? GetCustomerByName(string name);
        public Customer? UpdateCustomer(int customerId, string newAddress);
        public void DeleteCustomer(int customerId);
    }
}
