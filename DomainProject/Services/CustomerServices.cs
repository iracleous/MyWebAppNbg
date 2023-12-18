using DomainProject.Data;
using DomainProject.Dto;
using DomainProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Services;

    //CRUD implementation
public class CustomerServices : ICustomerServices
{
    private readonly EshopDbContext _context;
    public CustomerServices(EshopDbContext context)
    {
        _context = context;    
    }


    // Create a new Customer
    public async Task<ResponseApi<Customer>> CreateCustomerAsync(Customer customer)
    {
        int status = 0;
        string message;

        if (customer != null) 
        { 
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            message = "the customer has been successfully created";
        }
        else
        {
            status = -1;
            message = "the input was null and the customer has has not been created";
        }
        return new ResponseApi<Customer>
        {
            Data = customer,
            Status = status,
            Message = message
        };
    }

  // Read All
    public async Task<ResponseApi<List<Customer>>> GetCustomersAsync() 
    {
        return new ResponseApi<List<Customer>>
        {
            Data = await _context.Customers.ToListAsync(),
            Status = 0,
        };
    }


    ////Delete
    //public void DeleteCustomer(int customerId)
    //{
    //    Customer? customerForDelete = _context
    //        .Customers
    //        .Find(customerId);
    //    if (customerForDelete != null)
    //    {
    //        _context.Remove(customerForDelete);
    //        _context.SaveChanges();
    //    }
    //}

    //// Read by Id
    //public Customer? GetCustomerById(int customerId)
    //{
    //    Customer? customer = _context
    //        .Customers
    //        .Find(customerId);
    //    return customer;
    //}

    //public Customer? GetCustomerByName(string name)
    //{
    //    // Read by a
    //    Customer? customer = _context
    //        .Customers
    //        .Where(customer => name.Equals(customer.Name))
    //        .FirstOrDefault();
    //    return customer;
    //}

  
       
    //    //Update
    //public Customer? UpdateCustomer(int customerId, string newAddress)
    //{
    //    Customer? customerForUpdate = _context
    //     .Customers
    //     .Find(customerId);

    //    if (customerForUpdate != null)
    //    {
    //        customerForUpdate.Address = newAddress;
    //        _context.SaveChanges();
    //    }
    //    return customerForUpdate;
    //}
}
