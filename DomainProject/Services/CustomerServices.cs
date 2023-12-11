using DomainProject.Data;
using DomainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Services;

    //CRUD implementation
public class CustomerServices : ICustomerServices
{
    private readonly EshopDbContext context;
    public CustomerServices(EshopDbContext context)
    {
        this.context = context;    
    }

  
    // Create a new Customer
    public Customer? CreateCustomer(Customer customer)
    {
        context.Customers.Add(customer);
        context.SaveChanges();
        return customer;
    }

    //Delete
    public void DeleteCustomer(int customerId)
    {
        Customer? customerForDelete = context
            .Customers
            .Find(customerId);
        if (customerForDelete != null)
        {
            context.Remove(customerForDelete);
            context.SaveChanges();
        }
    }

    // Read by Id
    public Customer? GetCustomerById(int customerId)
    {
        Customer? customer = context
            .Customers
            .Find(customerId);
        return customer;
    }

    public Customer? GetCustomerByName(string name)
    {
        // Read by a
        Customer? customer = context
            .Customers
            .Where(customer => name.Equals(customer.Name))
            .FirstOrDefault();
        return customer;
    }

    // Read All
    public List<Customer> GetCustomers()
    {
        
        return  context.Customers.ToList() ;
    }
       
        //Update
    public Customer? UpdateCustomer(int customerId, string newAddress)
    {
        Customer? customerForUpdate = context
         .Customers
         .Find(customerId);

        if (customerForUpdate != null)
        {
            customerForUpdate.Address = newAddress;
            context.SaveChanges();
        }
        return customerForUpdate;
    }
}
